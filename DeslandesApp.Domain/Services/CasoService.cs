using AutoMapper;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
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
    public class CasoService(IUnitOfWork unitOfWork, IMapper mapper, IHistoricoGeralService historicoGeralService, FunctionsHelper functionsHelper) : ICasoService
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
                       // QualificacaoId = grupos.IdQualificacao,
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
            } //  N:N - ETIQUETAS (OPCIONAL)
            if (request.GrupoEtiquetaCasos != null && request.GrupoEtiquetaCasos.Any())
            {
                foreach (var item in request.GrupoEtiquetaCasos)
                {
                    if (item.EtiquetaId == Guid.Empty)
                        continue; // ou throw controlado

                    var etiqueta = await unitOfWork.EtiquetaRepository.GetByIdAsync(item.EtiquetaId);

                    if (etiqueta == null)
                        continue; // ou logar, ou ignorar

                    var grupoEtiqueta = new GrupoEtiquetaCasos
                    {
                        CasoId = caso.Id,
                        EtiquetaId = item.EtiquetaId
                    };

                    await unitOfWork.GrupoEtiquetaCasoRepository.AddAsync(grupoEtiqueta);
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
        public async Task<PageResult<CasoPaginacaoResponse>> ConsultarCasoPaginacaoAsync(
    int pageNumber,
    int pageSize,
    string? searchTerm = null)
        {
            var paged = await unitOfWork.CasoRepository
                .GetCasoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<CasoPaginacaoResponse>
                {
                    Items = new List<CasoPaginacaoResponse>(),
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

        public Task<CriarCasoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CriarCasoResponse> ModificarAsync(Guid id, CasoUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var caso = await unitOfWork.CasoRepository.GetByIdAsync(id)
                    ?? throw new ApplicationException("Caso não encontrado.");

                var usuarioId = functionsHelper.ObterUsuarioId();

                // =========================
                // SNAPSHOT ANTES
                // =========================
                var casoAntes = await unitOfWork.CasoRepository
                    .ConsultarCasoComRelacionamentosAsync(id);

                if (casoAntes == null)
                    throw new ApplicationException("Caso para histórico não encontrado.");

                var dadosAntes = new
                {
                    casoAntes.Pasta,
                    casoAntes.Titulo,
                    casoAntes.Descricao,
                    casoAntes.Observacao,
                    Acesso = casoAntes.Acesso.ToString(),

                    ResponsavelId = casoAntes.ResponsavelId,

                    Clientes = casoAntes.GrupoCasoClientes?
                        .Select(x => x.PessoaId)
                        .ToList(),

                    Envolvidos = casoAntes.GrupoCasoEnvolvidos?
                        .Select(x => x.PessoaId)
                        .ToList()
                };

                // =========================
                // CAMPOS BÁSICOS
                // =========================
                caso.Pasta = request.Pasta;
                caso.Titulo = request.Titulo;
                caso.Descricao = request.Descricao;
                caso.Observacao = request.Observacao;
                caso.Acesso = request.Acesso;
                caso.ResponsavelId = request.ResponsavelId;

                // =========================
                // 👥 CLIENTES (RESET)
                // =========================
                await unitOfWork.GrupoCasoClienteRepository.RemoverPorCasoId(id);

                if (request.GrupoCasoCliente?.Any() == true)
                {
                    foreach (var item in request.GrupoCasoCliente)
                    {
                        await unitOfWork.GrupoCasoClienteRepository.AddAsync(new GrupoCasoCliente
                        {
                            CasoId = id,
                            PessoaId = item.IdPessoa
                        });
                    }
                }

                // =========================
                // 👤 ENVOLVIDOS (RESET)
                // =========================
                await unitOfWork.GrupoCasoEnvolvidosRepository.RemoverPorCasoId(id);

                if (request.GrupoCasoEnvolvidos?.Any() == true)
                {
                    foreach (var item in request.GrupoCasoEnvolvidos)
                    {
                        await unitOfWork.GrupoCasoEnvolvidosRepository.AddAsync(new GrupoCasoEnvolvido
                        {
                            CasoId = id,
                            PessoaId = item.IdPessoa,
                            QualificacaoId = item.IdQualificacao
                        });
                    }
                }

                // =========================
                // UPDATE ENTIDADE
                // =========================
                await unitOfWork.CasoRepository.UpdateAsync(caso);

                // =========================
                // SNAPSHOT DEPOIS
                // =========================
                var casoDepois = await unitOfWork.CasoRepository
                    .ConsultarCasoComRelacionamentosAsync(id);

                if (casoDepois == null)
                    throw new ApplicationException("Caso atualizado não encontrado.");

                var dadosDepois = new
                {
                    casoDepois.Pasta,
                    casoDepois.Titulo,
                    casoDepois.Descricao,
                    casoDepois.Observacao,
                    Acesso = casoDepois.Acesso.ToString(),

                    ResponsavelId = casoDepois.ResponsavelId,

                    Clientes = casoDepois.GrupoCasoClientes?
                        .Select(x => x.PessoaId)
                        .ToList(),

                    Envolvidos = casoDepois.GrupoCasoEnvolvidos?
                        .Select(x => x.PessoaId)
                        .ToList()
                };

                // =========================
                // HISTÓRICO GERAL
                // =========================
                await historicoGeralService.RegistrarAsync(
                    TipoEntidade.Caso,
                    id,
                    usuarioId,
                    dadosAntes,
                    dadosDepois,
                    request.Observacao
                );

                await unitOfWork.CommitAsync();

                return mapper.Map<CriarCasoResponse>(casoDepois);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<ObterCasoResponse?> ObterPorIdAsync(Guid id)
        {
            var caso = await unitOfWork.CasoRepository.ObterCompletoPorIdAsync(id);

            if (caso == null)
                return null;

            return mapper.Map<ObterCasoResponse>(caso);
        }
        public async Task<List<CasoAutoComplete>> ConsultarCasoAutoCompleteAsync(string? termo = null)
        {
            return await unitOfWork.CasoRepository.ConsultarCasoAutoCompleteAsync(termo);
        }

       
    }
}
