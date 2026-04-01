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
using Newtonsoft.Json;
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
                atendimento.TipoVinculoId = TipoVinculo.Processo;
            }
            else if (request.CasoId.HasValue)
            {
                var caso = await unitOfWork.CasoRepository.GetByIdAsync(request.CasoId.Value);

                if (caso == null)
                    throw new InvalidOperationException("Caso não encontrado.");

                atendimento.CasoId = caso.Id;
                atendimento.TipoVinculoId = TipoVinculo.Caso;
            }
            else if (request.AtendimentoPaiId.HasValue)
            {
                var atendimentoPai = await unitOfWork.AtendimentoRepository.GetByIdAsync(request.AtendimentoPaiId.Value);

                if (atendimentoPai == null)
                    throw new InvalidOperationException("Atendimento pai não encontrado.");

                atendimento.AtendimentoPaiId = atendimentoPai.Id;
                atendimento.TipoVinculoId = TipoVinculo.Atendimento;
            }
            else
            {
                //  Sem vínculo
                atendimento.TipoVinculoId = null; // IMPORTANTE: TipoVinculo deve ser nullable
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

        public async Task<CriarAtendimentoClienteResponse> ModificarAsync(Guid id, AtendimentoClienteUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            var atendimento = await unitOfWork.AtendimentoRepository.GetByIdAsync(id);
            if (atendimento == null)
                throw new ApplicationException("Atendimento não encontrado.");

            var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(request.ResponsavelId!.Value);
            if (usuario == null)
                throw new ApplicationException("Usuário informado não encontrado.");

            // 🔎 ANTES (histórico)
            var atendimentoAntes = await unitOfWork.AtendimentoRepository
                .ConsultarAtendimentoComRelacionamentosAsync(id);

            if (atendimentoAntes == null)
                throw new ApplicationException("Atendimento para histórico não encontrado.");

            var dadosAntes = new
            {
                atendimentoAntes.Assunto,
                atendimentoAntes.Registro,
                atendimentoAntes.DataCadastro,

                Processo = atendimentoAntes.Processo?.Id,
                Caso = atendimentoAntes.Caso?.Id,
                AtendimentoPai = atendimentoAntes.AtendimentoPai?.Id,

                Responsavel = atendimentoAntes.Responsavel != null ? new
                {
                    atendimentoAntes.Responsavel.Id,
                    atendimentoAntes.Responsavel.NomeUsuario
                } : null,

                Clientes = atendimentoAntes.GrupoClientes?
                    .Select(c => c.Pessoa?.Nome)
                    .Where(n => n != null)
                    .ToList(),

                Etiquetas = atendimentoAntes.GrupoEtiquetasAtendimentos?
                    .Select(e => e.Etiqueta?.Nome)
                    .Where(n => n != null)
                    .ToList(),

                Usuario = new
                {
                    usuario.Id,
                    usuario.Login,
                    usuario.NomeUsuario
                }
            };

            // 🔄 ATUALIZAÇÃO

            // ⚠️ IMPORTANTE: evitar sobrescrever vínculos pelo AutoMapper
            mapper.Map(request, atendimento);

            // 🔥 REGRA CENTRAL DE VÍNCULO
            atendimento.DefinirVinculo(
                request.ProcessoId,
                request.CasoId,
                request.AtendimentoPaiId
            );

            atendimento.ResponsavelId = request.ResponsavelId;
            atendimento.DataAtualizacao = DateTime.Now;

            // 🔒 valida consistência
            atendimento.ValidarVinculo();

            await unitOfWork.AtendimentoRepository.UpdateAsync(atendimento);

            // 🔎 DEPOIS (histórico)
            var atendimentoDepois = await unitOfWork.AtendimentoRepository
                .ConsultarAtendimentoComRelacionamentosAsync(id);

            if (atendimentoDepois == null)
                throw new ApplicationException("Atendimento atualizado não encontrado.");

            var dadosDepois = new
            {
                atendimentoDepois.Assunto,
                atendimentoDepois.Registro,
                atendimentoDepois.DataCadastro,
                atendimentoDepois.DataAtualizacao,

                Processo = atendimentoDepois.Processo?.Id,
                Caso = atendimentoDepois.Caso?.Id,
                AtendimentoPai = atendimentoDepois.AtendimentoPai?.Id,

                Responsavel = atendimentoDepois.Responsavel?.NomeUsuario,

                Clientes = atendimentoDepois.GrupoClientes?
                    .Select(c => c.Pessoa?.Nome)
                    .Where(n => n != null)
                    .ToList(),

                Etiquetas = atendimentoDepois.GrupoEtiquetasAtendimentos?
                    .Select(e => e.Etiqueta?.Nome)
                    .Where(n => n != null)
                    .ToList(),

                Usuario = new
                {
                    usuario.Id,
                    usuario.Login,
                    usuario.NomeUsuario
                }
            };

            // 🧾 HISTÓRICO
            var historico = new AtendimentoHistorico
            {
                AtendimentoId = atendimento.Id,
                IdUsuario = request.ResponsavelId!.Value,
                DataAlteracao = DateTime.Now,
                Observacao = request.Observacao ?? "",
                DadosAntes = JsonConvert.SerializeObject(dadosAntes),
                DadosDepois = JsonConvert.SerializeObject(dadosDepois)
            };

            await unitOfWork.AtendimentoHistoricoRepository.AddAsync(historico);

            await unitOfWork.CommitAsync();

            return mapper.Map<CriarAtendimentoClienteResponse>(atendimentoDepois);
        }


        public Task<CriarAtendimentoClienteResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
