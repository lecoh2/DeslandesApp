using AutoMapper;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class PessoaFisicaService(IUnitOfWork unitOfWork, IMapper mapper) : IPessoaFisicaService
    {
        public async Task<PessoaFisicaResponse> AdicionarAsync(PessoaFisicaRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            var cpf = FunctionsHelper.RemovePontosTracos(request.Cpf);
            var rg = FunctionsHelper.RemovePontosTracos(request.Rg);

            if (!FunctionsHelper.ValidadorCPF(cpf))
                throw new ApplicationException("CPF inválido.");
            if (await unitOfWork.PessoaRepository.CpfInUseAsync(cpf))
                throw new ApplicationException("CPF já cadastrado.");

            if (!string.IsNullOrEmpty(rg) &&
                await unitOfWork.PessoaRepository.RgInUseAsync(rg))
                throw new ApplicationException("RG já cadastrado.");

            if (request.ValorEmail != null &&
                await unitOfWork.PessoaRepository.EmailInUseAsync(request.ValorEmail.EnderecoEmail))
                throw new ApplicationException("Email já cadastrado.");

            var pessoa = mapper.Map<PessoaFisica>(request);

            pessoa.DataCadastro = DateTime.Now;
            pessoa.CPF = cpf;
            pessoa.RG = rg;
            pessoa.Telefone = FunctionsHelper.RemovePontosTracosTelefone(pessoa.Telefone);

            pessoa.ValorEmail = string.IsNullOrWhiteSpace(pessoa.ValorEmail?.EnderecoEmail)
                ? new ValorEmail($"nadaconsta{cpf}@email.com")
                : pessoa.ValorEmail;

            await unitOfWork.PessoaRepository.AddAsync(pessoa);

            var endereco = mapper.Map<Endereco>(request);

            endereco.IdPessoa = pessoa.Id;
            endereco.Cep = FunctionsHelper.RemovePontosTracos(endereco.Cep);
            endereco.Complemento = "";

            await unitOfWork.EnderecoRepository.AddAsync(endereco);

            await unitOfWork.CommitAsync();

            return mapper.Map<PessoaFisicaResponse>(pessoa);
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
            throw new NotImplementedException();
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
