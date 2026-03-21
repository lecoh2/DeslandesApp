using AutoMapper;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.Validators;
using DeslandesApp.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class ProcessoService(IUnitOfWork unitOfWork, IMapper mapper) : IProcessoService
    {
        public async Task<ProcessoResponse> AdicionarAsync(ProcessoRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            //  DTO -> Entidade
            var processo = mapper.Map<Processo>(request);

            // 🧹 Normalização segura
            processo.Pasta = processo.Pasta?.Trim().ToUpper();
            processo.Titulo = processo.Titulo?.Trim().ToUpper();
            processo.NumeroProcesso = processo.NumeroProcesso?.Trim();
            processo.LinkTribunal = processo.LinkTribunal?.Trim();

            processo.DataCadastro = DateTime.Now;

            //  Responsável
            processo.UsuarioResponsavelId = request.UsuarioResponsavelId;

            //  Validação Fluent
            var validator = new ProcessoValidator();
            var result = validator.Validate(processo);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            //  VALIDA VARA
            if (processo.VaraId == Guid.Empty)
                throw new InvalidOperationException("Vara é obrigatória.");

            var vara = await unitOfWork.VaraRepository.GetByIdAsync(processo.VaraId);

            if (vara == null)
                throw new InvalidOperationException("Vara não encontrada.");

            //  VALIDA USUÁRIO RESPONSÁVEL (opcional se for obrigatório)
            if (processo.UsuarioResponsavelId.HasValue)
            {
                var usuario = await unitOfWork.UsuarioRepository
                    .GetByIdAsync(processo.UsuarioResponsavelId.Value);

                if (usuario == null)
                    throw new InvalidOperationException("Usuário responsável não encontrado.");
            }

            //  Verifica duplicidade
            var existente = await unitOfWork.ProcessoRepository.GetByAsync(p =>
                p.Pasta == processo.Pasta ||
                p.NumeroProcesso == processo.NumeroProcesso);

            if (existente != null)
            {
                if (existente.Pasta == processo.Pasta)
                    throw new InvalidOperationException("Nome de pasta já utilizado por outro processo.");

                if (existente.NumeroProcesso == processo.NumeroProcesso)
                    throw new InvalidOperationException("Nº do processo já cadastrado no sistema.");
            }

            //  Salva processo
            await unitOfWork.ProcessoRepository.AddAsync(processo);

            //  N:N - Clientes
            if (request.GrupoCliente != null && request.GrupoCliente.Any())
            {
                foreach (var grupos in request.GrupoCliente)
                {
                    var grupoCliente = new GrupoPessoaClientes
                    {
                        ProcessoId = processo.Id,
                        QualificacaoId = grupos.IdQualificacao,
                        PessoaId = grupos.IdPessoa
                    };

                    await unitOfWork.GrupoClientesRepository.AddAsync(grupoCliente);
                }
            }

            //  N:N - Envolvidos
            if (request.GrupoEnvolvidos != null && request.GrupoEnvolvidos.Any())
            {
                foreach (var grupos in request.GrupoEnvolvidos)
                {
                    var grupoEnvolvidos = new GrupoEnvolvidos
                    {
                        ProcessoId = processo.Id,
                        QualificacaoId = grupos.IdQualificacao,
                        PessoaId = grupos.IdPessoa
                    };

                    await unitOfWork.GrupoEnvolvidosRepository.AddAsync(grupoEnvolvidos);
                }
            }

            //  Commit único
            await unitOfWork.CommitAsync();

            //  Retorno
            return mapper.Map<ProcessoResponse>(processo);
        }

        public Task<PageResult<ProcessoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<ProcessoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessoResponse> ModificarAsync(Guid id, ProcessoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
