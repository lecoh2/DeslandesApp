using AutoMapper;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
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
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PessoaFisicaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PessoaFisicaResponse> AdicionarAsync(PessoaFisicaRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            var cpf = FunctionsHelper.RemovePontosTracos(request.Cpf);
            var rg = FunctionsHelper.RemovePontosTracos(request.Rg);

            if (!FunctionsHelper.ValidadorCPF(cpf))
                throw new ApplicationException("CPF inválido.");

            if (await _unitOfWork.PessoaRepository.CpfInUseAsync(cpf))
                throw new InvalidOperationException("CPF já cadastrado.");

            if (!string.IsNullOrWhiteSpace(rg) &&
                await _unitOfWork.PessoaRepository.RgInUseAsync(rg))
                throw new InvalidOperationException("RG já cadastrado.");

            var pessoa = _mapper.Map<PessoaFisica>(request);

            var validator = new PessoaFisicaValidator();
            var result = validator.Validate(pessoa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            pessoa.CPF = cpf;
            pessoa.RG = rg;
            pessoa.Telefone = FunctionsHelper.RemovePontosTracosTelefone(pessoa.Telefone);
            pessoa.DataCadastro = DateTime.Now;
            pessoa.IdSexo = request.IdSexo;

            pessoa.ValorEmail = string.IsNullOrWhiteSpace(pessoa.ValorEmail?.EnderecoEmail)
                ? new ValorEmail($"nadaconsta{cpf}@email.com")
                : pessoa.ValorEmail;

            if (await _unitOfWork.PessoaRepository.EmailInUseAsync(pessoa.ValorEmail.EnderecoEmail))
                throw new InvalidOperationException("Email já cadastrado.");

            // ENDEREÇO
            if (request.Endereco != null)
            {
                pessoa.Endereco = _mapper.Map<Endereco>(request.Endereco);
                pessoa.Endereco.Cep = FunctionsHelper.RemovePontosTracos(pessoa.Endereco.Cep);
                pessoa.Endereco.Complemento ??= "";
            }

            // INFORMAÇÕES COMPLEMENTARES
            if (TemAlgumValor(request.InformacoesComplementares))
            {
                pessoa.InformacoesComplementares =
                    _mapper.Map<InformacoesComplementaresPessoaFisica>(request.InformacoesComplementares);
            }

            // SALVA PESSOA PRIMEIRO (IMPORTANTE!)
            await _unitOfWork.PessoaRepository.AddAsync(pessoa);

            // N:N - ETIQUETAS (OPCIONAL)
            if (request.GrupoPessoasEtiquetas != null && request.GrupoPessoasEtiquetas.Any())
            {
                foreach (var item in request.GrupoPessoasEtiquetas)
                {
                    var etiqueta = await _unitOfWork.GrupoPessoasEtiquetasRepository.GetByIdAsync(item.idEtiqueta);

                    if (etiqueta == null)
                        throw new InvalidOperationException("Etiqueta não encontrada.");

                    var grupoEtiqueta = new GrupoPessoasEtiquetas
                    {
                        EtiquetaId = etiqueta.EtiquetaId,
                        PessoaId = pessoa.Id // ⚠️ corrigido aqui
                    };

                    await _unitOfWork.GrupoPessoasEtiquetasRepository.AddAsync(grupoEtiqueta);
                }
            }

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PessoaFisicaResponse>(pessoa);
        }


        public Task<PageResult<PessoaFisicaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }



        public async Task<PageResult<PessoaFisicaPaginacaoResponse>> ConsultarPessoaFisicaPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var paged = await _unitOfWork.PessoaRepository.PessoaFisicaComPaginacaoAsync
                (pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<PessoaFisicaPaginacaoResponse>
                {
                    Items = new List<PessoaFisicaPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<PessoaFisicaResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PessoaFisicaResponse> ModificarAsync(Guid id, PessoaFisicaUpdateRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var pessoa = await _unitOfWork.PessoaRepository.GetByIdAsync(id);

                if (pessoa == null)
                    throw new ApplicationException("Pessoa não encontrada para edição.");

                var pessoaAntes = await _unitOfWork
                    .PessoaRepository
                    .ConsultarPessoasFisicasComIdRelacionamentosAsync(id);

                var infoAntes = pessoaAntes.InformacoesComplementares as InformacoesComplementaresPessoaFisica;

                var dadosAntes = new
                {
                    pessoaAntes.Nome,
                    pessoaAntes.Apelido,
                    pessoaAntes.Telefone,
                    pessoaAntes.ValorEmail,
                    pessoaAntes.Site,
                    pessoaAntes.CPF,
                    pessoaAntes.RG,

                    Sexo = pessoaAntes.Sexo?.NomeSexo,

                    Usuario = pessoaAntes.Usuario != null ? new
                    {
                        pessoaAntes.Usuario.Id,
                        pessoaAntes.Usuario.Login,
                        pessoaAntes.Usuario.NomeUsuario
                    } : null,

                    Endereco = pessoaAntes.Endereco != null ? new
                    {
                        pessoaAntes.Endereco.Logradouro,
                        pessoaAntes.Endereco.Numero,
                        pessoaAntes.Endereco.Bairro,
                        pessoaAntes.Endereco.Localidade,
                        pessoaAntes.Endereco.Uf,
                        pessoaAntes.Endereco.Cep
                    } : null,

                    InformacoesComplementares = infoAntes != null ? new
                    {
                        pessoaAntes.InformacoesComplementares.Codigo,
                        pessoaAntes.InformacoesComplementares.Comentario,
                        infoAntes.DataNascimento,
                        infoAntes.NomeEmpresa,
                        infoAntes.Profissao,
                        infoAntes.AtividadeEconomica
                    } : null,

                    pessoaAntes.DataAtualizacao
                };

                pessoa.DataAtualizacao = DateTime.Now;

                _mapper.Map(request, pessoa);
                await _unitOfWork.PessoaRepository.UpdateAsync(pessoa);

                if (request.Endereco != null)
                {
                    var endereco = await _unitOfWork.EnderecoRepository.GetByAsync(e => e.IdPessoa == pessoa.Id);

                    if (endereco != null)
                    {
                        _mapper.Map(request.Endereco, endereco);
                        await _unitOfWork.EnderecoRepository.UpdateAsync(endereco);
                    }
                }

                if (request.InformacoesComplementares != null)
                {
                    var info = await _unitOfWork.InformacoesComplementaresRepository.GetByAsync(e => e.IdPessoa == pessoa.Id);

                    if (info != null)
                    {
                        _mapper.Map(request.InformacoesComplementares, info);
                        await _unitOfWork.InformacoesComplementaresRepository.UpdateAsync(info);
                    }
                }

                var pessoaDepois = await _unitOfWork
                    .PessoaRepository
                    .ConsultarPessoasFisicasComIdRelacionamentosAsync(id);

                var dadosDepois = new
                {
                    pessoaDepois.Nome,
                    pessoaDepois.Apelido,
                    pessoaDepois.Telefone,
                    pessoaDepois.ValorEmail,
                    pessoaDepois.Site,
                    pessoaDepois.CPF,
                    pessoaDepois.RG,
                    Sexo = pessoaDepois.Sexo?.NomeSexo,
                    pessoaDepois.DataAtualizacao
                };

                if (request.IdUsuario == null)
                    throw new ApplicationException("Id do usuário não informado.");

                var historico = new PessoaHistorico
                {
                    IdPessoa = pessoa.Id,
                    IdUsuario = request.IdUsuario.Value,
                    DataAlteracao = DateTime.Now,
                    Observacoes = request.Observacoes ?? "",
                    DadosAntes = JsonConvert.SerializeObject(dadosAntes),
                    DadosDepois = JsonConvert.SerializeObject(dadosDepois)
                };

                await _unitOfWork.PessoaHistoricoRepository.AddAsync(historico);

                await _unitOfWork.CommitAsync();

                return _mapper.Map<PessoaFisicaResponse>(pessoaDepois);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PessoaFisicaResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        private bool TemAlgumValor(InformacoesComplementaresRequest info)
        {
            if (info == null) return false;

            return !string.IsNullOrWhiteSpace(info.DataNascimento)
                || !string.IsNullOrWhiteSpace(info.NomeEmpresa)
                || !string.IsNullOrWhiteSpace(info.Profissao)
                || !string.IsNullOrWhiteSpace(info.AtividadeEconomica)
                || !string.IsNullOrWhiteSpace(info.EstadoCivil)
                || !string.IsNullOrWhiteSpace(info.Codigo)
                || !string.IsNullOrWhiteSpace(info.NomePai)
                || !string.IsNullOrWhiteSpace(info.NomeMae)
                || !string.IsNullOrWhiteSpace(info.Naturalidade)
                || !string.IsNullOrWhiteSpace(info.Nacionalidade)
                || !string.IsNullOrWhiteSpace(info.Comentario);
        }
    }
}
