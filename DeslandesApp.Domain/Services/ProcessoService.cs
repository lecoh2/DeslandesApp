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
using Newtonsoft.Json;
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
            processo.Instancia = request.Instancia.HasValue
     ? (Instancia?)request.Instancia.Value
     : null;
            processo.Acesso = request.Acesso.HasValue
     ? (Acesso?)request.Acesso.Value : null;
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
            if (request.GrupoClienteProcesso != null && request.GrupoClienteProcesso.Any())
            {
                foreach (var grupos in request.GrupoClienteProcesso)
                {
                    var grupoClienteProcesso = new GrupoClienteProcesso
                    {
                        ProcessoId = processo.Id,
                        QualificacaoId = grupos.IdQualificacao,
                        PessoaId = grupos.IdPessoa.Value
                    };

                    await unitOfWork.GrupoClientesProcessosRepository.AddAsync(grupoClienteProcesso);
                }
            }

            //  N:N - Envolvidos
            if (request.GrupoEnvolvidosProcesso != null && request.GrupoEnvolvidosProcesso.Any())
            {
                foreach (var grupos in request.GrupoEnvolvidosProcesso)
                {
                    var grupoEnvolvidos = new GrupoEnvolvidosProcesso
                    {
                        ProcessoId = processo.Id,
                        QualificacaoId = grupos.IdQualificacao,
                        PessoaId = grupos.IdPessoa
                    };

                    await unitOfWork.GrupoEnvolvidosProcessosRepository.AddAsync(grupoEnvolvidos);
                }
            }
            if (request.GrupoEtiquetasProcesso != null && request.GrupoEtiquetasProcesso.Any())
            {
                foreach (var grupoEtiqueta in request.GrupoEtiquetasProcesso)
                {
                    var etiqueta = await unitOfWork.EtiquetaRepository.GetByIdAsync(grupoEtiqueta.EtiquetaId);
                    if (etiqueta == null) throw new InvalidOperationException("Etiqueta não encontrada.");
                    var processoEtiqueta = new GrupoEtiquetasProcessos
                    {
                        ProcessoId = processo.Id,
                        EtiquetaId = grupoEtiqueta.EtiquetaId
                    };
                    await unitOfWork.GrupoEtiquetasProcessosRepository.AddAsync(processoEtiqueta);
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

   
        public async Task<PageResult<ProcessoPaginacaoResponse>> ConsultarProcessoPaginacaoAsync(
      int pageNumber,
      int pageSize,
      string? searchTerm = null)
        {
            var paged = await unitOfWork.ProcessoRepository
                .GetProcessoPaginacaoAsync(pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<ProcessoPaginacaoResponse>
                {
                    Items = new List<ProcessoPaginacaoResponse>(),
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

        public Task<ProcessoResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessoResponse> ModificarAsync(Guid id, ProcessoUpdateRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            var processo = await unitOfWork.ProcessoRepository.GetByIdAsync(id);
            if (processo == null)
                throw new ApplicationException("Processo não encontrado.");

            var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(request.UsuarioResponsavelId!.Value);
            if (usuario == null)
                throw new ApplicationException("Usuário informado não encontrado.");

            // 🔎 Antes (com relacionamentos completos)
            var processoAntes = await unitOfWork.ProcessoRepository
                .ConsultarProcessoComRelacionamentosAsync(id);

            if (processoAntes == null)
                throw new ApplicationException("Processo para histórico não encontrado.");

            var dadosAntes = new
            {
                processoAntes.Titulo,
                processoAntes.Pasta,
                processoAntes.NumeroProcesso,
                processoAntes.LinkTribunal,
                processoAntes.Objeto,
                processoAntes.ValorCausa,
                processoAntes.ValorCondenacao,
                processoAntes.Distribuido,
                processoAntes.Observacao,
                Instancia = processoAntes.Instancia?.ToString(),
                Acesso = processoAntes.Acesso?.ToString(),

                Vara = processoAntes.Vara != null ? new
                {
                    processoAntes.Vara.Id,
                    processoAntes.Vara.NomeVara
                } : null,

                UsuarioResponsavel = processoAntes.UsuarioResponsavel != null ? new
                {
                    processoAntes.UsuarioResponsavel.Id,
                    processoAntes.UsuarioResponsavel.NomeUsuario
                } : null,

                Acao = processoAntes.Acao != null ? new
                {
                    processoAntes.Acao.Id,
                    processoAntes.Acao.NomeAcao
                } : null,

                // 🔥 AQUI você só TRAZ, não altera
                //Clientes = processoAntes.GrupoPessoaClientes?
                //    .Select(c => c.Pessoa?.Nome)
                //    .Where(n => n != null)
                //    .ToList(),

                Envolvidos = processoAntes.GrupoEnvolvidos?
                    .Select(e => new
                    {
                        Nome = e.Pessoa?.Nome,
                       // e.TipoEnvolvido
                    })
                    .Where(e => e.Nome != null)
                    .ToList(),

                Usuario = usuario != null ? new
                {
                    usuario.Id,
                    usuario.Login,
                    NomeUsuario = usuario.NomeUsuario
                } : null
            };

            // 🔄 Atualiza entidade
            mapper.Map(request, processo);
            processo.UsuarioResponsavelId = request.UsuarioResponsavelId;
           // processo.DataAtualizacao = DateTime.Now;

            await unitOfWork.ProcessoRepository.UpdateAsync(processo);

            // 🔎 Depois (já atualizado)
            var processoDepois = await unitOfWork.ProcessoRepository
                .ConsultarProcessoComRelacionamentosAsync(id);

            if (processoDepois == null)
                throw new ApplicationException("Processo atualizado não encontrado.");

            var dadosDepois = new
            {
                processoDepois.Titulo,
                processoDepois.Pasta,
                processoDepois.NumeroProcesso,
                processoDepois.LinkTribunal,
                processoDepois.Objeto,
                processoDepois.ValorCausa,
                processoDepois.ValorCondenacao,
                processoDepois.Distribuido,
                processoDepois.Observacao,
                Instancia = processoDepois.Instancia?.ToString(),
                Acesso = processoDepois.Acesso?.ToString(),
                Vara = processoDepois.Vara?.NomeVara,
                UsuarioResponsavel = processoDepois.UsuarioResponsavel?.NomeUsuario,
                Acao = processoDepois.Acao?.NomeAcao,

                //Clientes = processoDepois.GrupoPessoaClientes?
                //    .Select(c => c.Pessoa?.Nome)
                //    .Where(n => n != null)
                //    .ToList(),

                Envolvidos = processoDepois.GrupoEnvolvidos?
                    .Select(e => new
                    {
                        Nome = e.Pessoa?.Nome,
                       // e.TipoEnvolvido
                    })
                    .Where(e => e.Nome != null)
                    .ToList(),

                Usuario = usuario != null ? new
                {
                    usuario.Id,
                    usuario.Login,
                    NomeUsuario = usuario.NomeUsuario
                } : null
            };

            // 🧾 Histórico
            mapper.Map(request, processo);
            processo.UsuarioResponsavelId = request.UsuarioResponsavelId;

            //var historico = new ProcessoHistorico
            //{
            //    ProcessoId = processo.Id,
            //    IdUsuario = request.UsuarioResponsavelId!.Value,
            //    DataAlteracao = DateTime.Now,
            //    Observacoes = request.Observacao ?? "",
            //    DadosAntes = JsonConvert.SerializeObject(dadosAntes),
            //    DadosDepois = JsonConvert.SerializeObject(dadosDepois)
            //};

           // await unitOfWork.ProcessoHistoricoRepository.AddAsync(historico);

      

            await unitOfWork.CommitAsync();

            return mapper.Map<ProcessoResponse>(processoDepois);
        }

        public Task<ProcessoResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task AdicionarSetorAsync(Guid idUsuario, Guid idSetor)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(idUsuario);
                if (usuario is null)
                    throw new ApplicationException("Usuário não encontrado.");

                var setor = await unitOfWork.SetorRepository.GetByIdAsync(idSetor);
                if (setor is null)
                    throw new ApplicationException("Setor não encontrado.");

                var existeVinculo = await unitOfWork.GrupoSetoresRepository
                    .ExistUsuarioSetorAsync(idUsuario, idSetor);

                if (existeVinculo != null)
                    throw new ApplicationException("Este usuário já está vinculado a esse setor.");

                var grupoSetor = new GrupoSetores
                {
                    IdUsuario = idUsuario,
                    IdSetor = idSetor
                };

                await unitOfWork.GrupoSetoresRepository.AddAsync(grupoSetor);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task RemoverSetorAsync(Guid idUsuario, Guid idSetor)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoSetoresRepository
                    .GetByIdUSuarioIdSetor(idUsuario, idSetor);

                if (entidade is null)
                    throw new ApplicationException("Vínculo entre usuário e setor não encontrado.");

                await unitOfWork.GrupoSetoresRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<List<ProcessoAutoComplete>> ConsultarProcessoAutoCompleteAsync(string? termo = null)
        {
            return await unitOfWork.ProcessoRepository.ConsultarProcessoAutoCompleteAsync(termo);
        }
    }
}
