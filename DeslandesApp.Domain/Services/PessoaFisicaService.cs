using AutoMapper;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
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
            if (request.InformacoesComplementares != null)
            {
                pessoa.InformacoesComplementares =
                    _mapper.Map<InformacoesComplementares>(request.InformacoesComplementares);
            }

            // SALVA TUDO JUNTO
            await _unitOfWork.PessoaRepository.AddAsync(pessoa);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PessoaFisicaResponse>(pessoa);
        }

        public Task<PageResult<PessoaFisicaResponse>> ConsultarAsync(int pageNumber, int pageSize, string? serchTerms = null)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<PessoaFisicaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<PessoaFisicaResponse>> ConsultarPaginacaoAsync(int pageNumber, int pageSize, string? serchTerm = null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<PessoaFisicaResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaFisicaResponse> ModificarAsync(Guid id, PessoaFisicaUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaFisicaResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
