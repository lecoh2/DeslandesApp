using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
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
    public class AtendiemntoService(IUnitOfWork unitOfWork, IMapper mapper) : IAtendimentoService
    {
        public async Task<CriarAtendimentoClienteResponse> AdicionarAsync(CriarAtendimentoClienteRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            //  DTO -> Entidade
            var atendimento = mapper.Map<Atendimento>(request);

            //  Normalização
            atendimento.Assunto = atendimento.Assunto?.Trim().ToUpper();
            atendimento.Registro = atendimento.Registro?.Trim();
            atendimento.DataCadastro = DateTime.Now;
            atendimento.DataAtualizacao = DateTime.Now;

            //  Responsável
            atendimento.ResponsavelId = request.ResponsavelId;

            //  VALIDAÇÃO DE VÍNCULO (AGORA OPCIONAL)
            int count = 0;

            if (request.ProcessoId.HasValue) count++;
            if (request.CasoId.HasValue) count++;
            if (request.AtendimentoPaiId.HasValue) count++;

            if (count > 1)
                throw new InvalidOperationException("O atendimento não pode ter mais de um vínculo.");

            //  RESOLVE VÍNCULO AUTOMATICAMENTE (SE EXISTIR)
            if (request.ProcessoId.HasValue)
            {
                var processo = await unitOfWork.ProcessoRepository.GetByIdAsync(request.ProcessoId.Value);

                if (processo == null)
                    throw new InvalidOperationException("Processo não encontrado.");

                atendimento.ProcessoId = processo.Id;
                atendimento.TipoVinculo = TipoVinculo.Processo;
            }
            else if (request.CasoId.HasValue)
            {
                var caso = await unitOfWork.CasoRepository.GetByIdAsync(request.CasoId.Value);

                if (caso == null)
                    throw new InvalidOperationException("Caso não encontrado.");

                atendimento.CasoId = caso.Id;
                atendimento.TipoVinculo = TipoVinculo.Caso;
            }
            else if (request.AtendimentoPaiId.HasValue)
            {
                var atendimentoPai = await unitOfWork.AtendimentoRepository.GetByIdAsync(request.AtendimentoPaiId.Value);

                if (atendimentoPai == null)
                    throw new InvalidOperationException("Atendimento pai não encontrado.");

                atendimento.AtendimentoPaiId = atendimentoPai.Id;
                atendimento.TipoVinculo = TipoVinculo.Atendimento;
            }
            else
            {
                //  Sem vínculo
                atendimento.TipoVinculo = null; // IMPORTANTE: TipoVinculo deve ser nullable
            }

            //  VALIDA REGRA DE DOMÍNIO
            atendimento.ValidarVinculo();

            //  Validação Fluent
            var validator = new AtendimentoValidator();
            var result = validator.Validate(atendimento);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            //  VALIDA RESPONSÁVEL
            if (atendimento.ResponsavelId.HasValue)
            {
                var usuario = await unitOfWork.UsuarioRepository
                    .GetByIdAsync(atendimento.ResponsavelId.Value);

                if (usuario == null)
                    throw new InvalidOperationException("Responsável não encontrado.");
            }

            //  Salva Atendimento
            await unitOfWork.AtendimentoRepository.AddAsync(atendimento);

            //  N:N - CLIENTES
            if (request.GrupoAtendimentoCliente != null && request.GrupoAtendimentoCliente.Any())
            {
                foreach (var item in request.GrupoAtendimentoCliente)
                {
                    var pessoa = await unitOfWork.PessoaRepository.GetByIdAsync(item.PessoaId.Value);

                    if (pessoa == null)
                        throw new InvalidOperationException("Pessoa não encontrada.");

                    var grupoCliente = new GrupoAtendimentoCliente
                    {
                        AtendimentoId = atendimento.Id,
                        PessoaId = item.PessoaId.Value
                    };

                    await unitOfWork.GrupoAtendimentoClienteRepository.AddAsync(grupoCliente);
                }
            }

            //  N:N - ETIQUETAS (OPCIONAL)
            if (request.GrupoEtiquetas != null && request.GrupoEtiquetas.Any())
            {
                foreach (var item in request.GrupoEtiquetas)
                {
                    var etiqueta = await unitOfWork.EtiquetaRepository.GetByIdAsync(item.EtiquetaId);

                    if (etiqueta == null)
                        throw new InvalidOperationException("Etiqueta não encontrada.");

                    var grupoEtiqueta = new GrupoEtiquetasAtendimentos
                    {
                        AtendimentoId = atendimento.Id,
                        EtiquetaId = item.EtiquetaId
                    };

                    await unitOfWork.GrupoEtiquetasAtendimentoRepository.AddAsync(grupoEtiqueta);
                }
            }

            //  Commit
            await unitOfWork.CommitAsync();

            return mapper.Map<CriarAtendimentoClienteResponse>(atendimento);
        }
        public Task<PageResult<CriarAtendimentoClienteResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<PageResult<AtendimentoPaginacaoResponse>> ConsultarAtendimentoPaginacaoAsync(
     int pageNumber,
     int pageSize,
     string? searchTerm = null)
        {
            var paged = await unitOfWork.AtendimentoRepository
                .GetAtendimentoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<AtendimentoPaginacaoResponse>
                {
                    Items = new List<AtendimentoPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<CriarAtendimentoClienteResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CriarAtendimentoClienteResponse> ModificarAsync(Guid id, AtendimentoClienteUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CriarAtendimentoClienteResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
