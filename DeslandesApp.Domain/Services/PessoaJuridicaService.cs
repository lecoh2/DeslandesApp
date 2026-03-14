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

        public Task<PessoaJuridicaResponse> ModificarAsync(Guid id, PessoaJuridicaUpdateRequest request)
        {
            throw new NotImplementedException();
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

       