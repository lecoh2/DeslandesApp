using AutoMapper;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Entities;
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
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PessoaJuridicaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PessoaJuridicaResponse> AdicionarAsync(PessoaJuridicaRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            var cnpj = FunctionsHelper.RemovePontosTracos(request.Cnpj);
            var incricaoEstadual = FunctionsHelper.RemovePontosTracos(request.InscricaoEstadual);

            if (!FunctionsHelper.ValidadorCNPJ(cnpj))
                throw new ApplicationException("Cnpj inválido.");

            if (await _unitOfWork.PessoaRepository.CnpjInUseAsync(cnpj))
                throw new InvalidOperationException("CNPJ já cadastrado.");

            if (!string.IsNullOrWhiteSpace(incricaoEstadual) &&
                await _unitOfWork.PessoaRepository.IncricaoEstadualInUseAsync(incricaoEstadual))
                throw new InvalidOperationException("RG já cadastrado.");

            var pessoa = _mapper.Map<PessoaJuridica>(request);

            var validator = new PessoaJuridicaValidator();
            var result = validator.Validate(pessoa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            pessoa.CNPJ = cnpj;
            pessoa.InscricaoEstadual = incricaoEstadual;
            pessoa.Telefone = FunctionsHelper.RemovePontosTracosTelefone(pessoa.Telefone);
            pessoa.DataCadastro = DateTime.Now;


            pessoa.ValorEmail = string.IsNullOrWhiteSpace(pessoa.ValorEmail?.EnderecoEmail)
                ? new ValorEmail($"nadaconsta{cnpj}@email.com")
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
            // INFORMAÇÕES COMPLEMENTARES
            if (request.InformacoesComplementares != null &&
    TemAlgumValor(request.InformacoesComplementares))
            {
                pessoa.InformacoesComplementares =
                    _mapper.Map<InformacoesComplementaresPessoaJuridica>(
                        request.InformacoesComplementares);
            }

            // SALVA TUDO JUNTO
            await _unitOfWork.PessoaRepository.AddAsync(pessoa);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PessoaJuridicaResponse>(pessoa);
        }

        public Task<PageResult<PessoaJuridicaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<PessoaJuridicaResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PessoaJuridicaResponse> ModificarAsync(Guid id, PessoaJuridicaUpdateRequest request)
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

                var infoAntes = pessoaAntes.InformacoesComplementares as InformacoesComplementaresPessoaJuridica;

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
                        infoAntes.Contato,
                        infoAntes.Cargo,
                        infoAntes.Agencia,
                        infoAntes.NumeroConta

                        
    } : null,

                    pessoaAntes.DataAtualizacao
                };

                pessoa.DataAtualizacao = DateTime.Now;

                _mapper.Map(request, pessoa);
                await _unitOfWork.PessoaRepository.UpdateAsync(pessoa);

                if (request.Endereco != null)
                {
                    var endereco = await _unitOfWork.EnderecoRepository.GetByIdAsync(pessoa.Id);

                    if (endereco != null)
                    {
                        _mapper.Map(request.Endereco, endereco);
                        await _unitOfWork.EnderecoRepository.UpdateAsync(endereco);
                    }
                }

                if (request.InformacoesComplementares != null)
                {
                    var info = await _unitOfWork.InformacoesComplementaresRepository.GetByIdAsync(pessoa.Id);

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

                return _mapper.Map<PessoaJuridicaResponse>(pessoaDepois);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PessoaJuridicaResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<PageResult<PessoaJuridicaPaginacaoResponse>> ConsultarPessoaJuridicaPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var paged = await _unitOfWork.PessoaRepository.ConsultarPessoaJuridicaComPaginacaoAsync
                (pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<PessoaJuridicaPaginacaoResponse>
                {
                    Items = new List<PessoaJuridicaPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }
        private bool TemAlgumValor(InformacoesComplementaresJuridicaRequest info)
        {
            if (info == null) return false;

            return !string.IsNullOrWhiteSpace(info.Contato)
                || !string.IsNullOrWhiteSpace(info.Cargo)
                || !string.IsNullOrWhiteSpace(info.NomeBanco)
                || !string.IsNullOrWhiteSpace(info.Agencia)
                || !string.IsNullOrWhiteSpace(info.NumeroConta)
                || !string.IsNullOrWhiteSpace(info.Pix);


        }
    }
}

       