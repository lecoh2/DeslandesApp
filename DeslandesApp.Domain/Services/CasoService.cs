using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class CasoService(IUnitOfWork unitOfWork, IMapper mapper) : ICasoService
    {
        public async Task<CriarCasoResponse> AdicionarAsync(CriarCasoRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            //  DTO -> Entidade
            var caso = mapper.Map<Caso>(request);

            //  Normalização
            caso.Pasta = caso.Pasta?.Trim().ToUpper();
            caso.Titulo = caso.Titulo?.Trim().ToUpper();
            caso.Descricao = caso.Descricao?.Trim();
            caso.Observacao = caso.Observacao?.Trim();

            // (se tiver DataCadastro no BaseEntity)
            caso.DataCadastro = DateTime.Now;

            //  Responsável
            caso.ResponsavelId = request.ResponsavelId;

            //  Validação Fluent
            var validator = new CasoValidator();
            var result = validator.Validate(caso);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            //  VALIDA RESPONSÁVEL (opcional)
            if (caso.ResponsavelId.HasValue)
            {
                var pessoa = await unitOfWork.UsuarioRepository
                    .GetByIdAsync(caso.ResponsavelId.Value);

                if (pessoa == null)
                    throw new InvalidOperationException("Responsável não encontrado.");
            }

            //  Verifica duplicidade (por Pasta)
            var existente = await unitOfWork.CasoRepository
                .GetByAsync(c => c.Pasta == caso.Pasta);

            if (existente != null)
                throw new InvalidOperationException("Nome de pasta já utilizado por outro caso.");

            //  Salva Caso
            await unitOfWork.CasoRepository.AddAsync(caso);

            //  N:N - Clientes
            if (request.GrupoCasoClientes != null && request.GrupoCasoClientes.Any())
            {
                foreach (var grupos in request.GrupoCasoClientes)
                {
                    var grupoCliente = new GrupoCasoCliente
                    {
                        CasoId = caso.Id,
                        QualificacaoId = grupos.IdQualificacao,
                        PessoaId = grupos.IdPessoa
                    };

                    await unitOfWork.GrupoCasoClienteRepository.AddAsync(grupoCliente);
                }
            }

            //  N:N - Envolvidos
            if (request.GrupoCasoEnvolvidos != null && request.GrupoCasoEnvolvidos.Any())
            {
                foreach (var grupos in request.GrupoCasoEnvolvidos)
                {
                    var grupoEnvolvido = new GrupoCasoEnvolvido
                    {
                        CasoId = caso.Id,
                        QualificacaoId = grupos.IdQualificacao,
                        PessoaId = grupos.IdPessoa
                    };

                    await unitOfWork.GrupoCasoEnvolvidosRepository.AddAsync(grupoEnvolvido);
                }
            }

            //  Commit
            await unitOfWork.CommitAsync();

            //  Retorno
            return mapper.Map<CriarCasoResponse>(caso);
        }

        public Task<PageResult<CriarCasoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<CriarCasoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CriarCasoResponse> ModificarAsync(Guid id, CasoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CriarCasoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
