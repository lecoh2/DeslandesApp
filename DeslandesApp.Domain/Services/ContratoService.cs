using AutoMapper;
using DeslandesApp.Domain.Exceptions;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Contrato;
using DeslandesApp.Domain.Models.Dtos.Responses.Contrato;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DeslandesApp.Domain.Services
{
    public class ContratoService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor, IHistoricoGeralService historicoGeralService
    ) : BaseService(httpContextAccessor), IContratoService
    {
        public async Task<ContratoResponse> AdicionarAsync(
      ContratoRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var numeroContrato = request.Numero?
    .Trim()
    .Replace("-", "");

                if (!Regex.IsMatch(numeroContrato, @"^\d+$"))
                {
                    throw new BusinessException("O número do contrato deve conter apenas números.");
                }
                var pessoa =
                    await unitOfWork.PessoaRepository
                        .GetByIdAsync(request.PessoaId);

                if (pessoa == null)
                    throw new BusinessException(
                        "Cliente não encontrado.");

                if (request.ProcessosIds == null ||
                    !request.ProcessosIds.Any())
                {
                    throw new BusinessException(
                        "Selecione pelo menos um processo.");
                }
                var processosJaVinculados =
     await unitOfWork.ContratoProcessoRepository
         .VerificarProcessosJaVinculadosAsync(request.ProcessosIds);

                if (processosJaVinculados.Any())
                {
                    var mensagem = string.Join(
                        "; ",
                        processosJaVinculados.Select(x =>
                            $"Processo {x.NumeroProcesso} já vinculado ao contrato {x.NumeroContrato}")
                    );

                    throw new BusinessException(mensagem);
                }
                foreach (var processoId in request.ProcessosIds)
                {
                    var processo =
                        await unitOfWork.ProcessoRepository
                            .GetByIdAsync(processoId);

                    if (processo == null)
                    {
                        throw new BusinessException(
                            $"Processo {processoId} não encontrado.");
                    }
                }

                var contrato = mapper.Map<Contrato>(request);
                contrato.DataCadastro = DateTime.Now;

                await unitOfWork.ContratoRepository
                    .AddAsync(contrato);

                foreach (var processoId in request.ProcessosIds)
                {
                    await unitOfWork.ContratoProcessoRepository
                        .AddAsync(new ContratoProcesso
                        {
                            ContratoId = contrato.Id,
                            ProcessoId = processoId
                        });
                }

                await unitOfWork.CommitAsync();

                return mapper.Map<ContratoResponse>(contrato);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<ContratoResponse> ModificarAsync(
     Guid id,
     ContratoUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var contrato = await unitOfWork
                    .ContratoRepository
                    .GetByIdAsync(id)
                    ?? throw new BusinessException(
                        "Contrato não encontrado."
                    );
               
                var usuarioId = ObterUsuarioId();

                // =========================
                // SNAPSHOT ANTES
                // =========================
                var contratoAntes = await unitOfWork
                    .ContratoRepository
                    .ObterCompletoPorIdAsync(id);

                var dadosAntes = new
                {
                    contratoAntes.Numero,
                    contratoAntes.PessoaId,
                    NomePessoa = contratoAntes.Pessoa?.Nome,
                 
                    contratoAntes.DataInicio,
                    contratoAntes.DataFim,

                    Processos = contratoAntes.ContratoProcessos?
                        .Select(x => x.Processo?.NumeroProcesso)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList()
                };

                // =========================
                // CAMPOS BÁSICOS
                // =========================
                contrato.Numero = request.Numero?
                    .Trim();
                                contrato.PessoaId = request.PessoaId;

         

          

                contrato.DataInicio = request.DataInicio;

                contrato.DataFim = request.DataFim;

                contrato.Status = request.Status;

                contrato.DataAtualizacao = DateTime.Now;

                // =========================
                // VALIDA CLIENTE
                // =========================
                var pessoa = await unitOfWork
                    .PessoaRepository
                    .GetByIdAsync(request.PessoaId);

                if (pessoa == null)
                    throw new BusinessException("Cliente não encontrado.");

                // =========================
                // RESET PROCESSOS
                // =========================
                await unitOfWork
                    .ContratoProcessoRepository
                    .RemoverPorContratoIdAsync(id);
                if (request.ProcessosIds?.Any() == true)
                {
                    var processosJaVinculados = await unitOfWork
                        .ContratoProcessoRepository
                        .VerificarProcessosJaVinculadosAsync(
                            request.ProcessosIds,
                            id);

                    if (processosJaVinculados.Any())
                    {
                        var mensagem = string.Join(
                            "; ",
                            processosJaVinculados.Select(x =>
                                $"Processo {x.NumeroProcesso} já vinculado ao contrato {x.NumeroContrato}")
                        );

                        throw new BusinessException(mensagem);
                    }
                }
                if (request.ProcessosIds?.Any() == true)
                {
                    foreach (var processoId in request.ProcessosIds)
                    {
                        await unitOfWork
                            .ContratoProcessoRepository
                            .AddAsync(new ContratoProcesso
                            {
                                ContratoId = id,
                                ProcessoId = processoId
                            });
                    }
                }

                // =========================
                // UPDATE
                // =========================
                await unitOfWork
                    .ContratoRepository
                    .UpdateAsync(contrato);

                // =========================
                // SNAPSHOT DEPOIS
                // =========================
                var contratoDepois = await unitOfWork
                    .ContratoRepository
                    .ObterCompletoPorIdAsync(id);

                var dadosDepois = new
                {
                    contratoDepois.Numero,
                    contratoDepois.PessoaId,
                    NomePessoa = contratoDepois.Pessoa?.Nome,
                
                    contratoDepois.DataInicio,
                    contratoDepois.DataFim,

                    Processos = contratoDepois.ContratoProcessos?
                        .Select(x => x.Processo?.NumeroProcesso)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList()
                };

                // =========================
                // HISTÓRICO
                // =========================
                await historicoGeralService.RegistrarAsync(
                    TipoEntidade.Contrato,
                    id,
                    usuarioId,
                    dadosAntes,
                    dadosDepois,
                    request.Observacao
                );

                // =========================
                // COMMIT
                // =========================
                await unitOfWork.CommitAsync();

                return mapper.Map<ContratoResponse>(contratoDepois);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<ContratoResponse> ExcluirAsync(Guid id)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var contrato = await unitOfWork
                    .ContratoRepository
                    .GetByIdAsync(id);

                if (contrato == null)
                    throw new ApplicationException(
                        "Contrato não encontrado."
                    );

                contrato.Excluido = true;
                contrato.DataExclusao = DateTime.Now;
                contrato.UsuarioExclusaoId = ObterUsuarioId();

                await unitOfWork.ContratoRepository
                    .UpdateAsync(contrato);

                await unitOfWork.CommitAsync();

                return mapper.Map<ContratoResponse>(contrato);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<List<ContratoResponse>> ConsultarAsync()
        {
            var contratos = await unitOfWork
                .ContratoRepository
                .GetAllAsync();

            return mapper.Map<List<ContratoResponse>>(contratos);
        }

        public async Task<PageResult<ContratoResponse>> ConsultarAsync(
            int pageNumber,
            int pageSize)
        {
            var result = await unitOfWork
                .ContratoRepository
                .GetAllAsync(pageNumber, pageSize);

            return new PageResult<ContratoResponse>
            {
                Items = mapper.Map<List<ContratoResponse>>(result.Items),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<PageResult<ContratoPaginacaoResponse>> ConsultarContratoPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {

            var paged = await unitOfWork.ContratoRepository
                .ConsultarContratoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<ContratoPaginacaoResponse>
                {
                    Items = new List<ContratoPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }
        public async Task<ObterContratoResponse?> ObterPorIdAsync(Guid id)
        {
            var contrato = await unitOfWork.ContratoRepository.ObterCompletoPorIdAsync(id);

            if (contrato == null)
                return null;

            return mapper.Map<ObterContratoResponse>(contrato);
        }
    }
}

