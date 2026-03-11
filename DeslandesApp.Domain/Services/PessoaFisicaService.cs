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
    public class PessoaFisicaService(IUnitOfWork unitOfWork, IMapper mapper) : IPessoaFisicaService
    {
        public async Task<PessoaFisicaResponse> AdicionarAsync(PessoaFisicaRequest request)
        {
            await unitOfWork.BeginTransactionAsync();

            // 1. Mapeia DTO -> Entidade
            var pessoa = mapper.Map<PessoaFisica>(request);
            // Informações complementares (opcional)
            // Informações complementares (opcional)
            if (request.InformacoesComplementares != null)
            {
                pessoa.InformacoesComplementares =
                    mapper.Map<InformacoesComplementares>(request.InformacoesComplementares);
            }
            // Sexo (opcional)
           
            
            
            // 2. Normalização de dados
            var cpf = FunctionsHelper.RemovePontosTracos(request.Cpf);
            var rg = FunctionsHelper.RemovePontosTracos(request.Rg);

            pessoa.CPF = cpf;
            pessoa.RG = rg;
            pessoa.Telefone = FunctionsHelper.RemovePontosTracosTelefone(pessoa.Telefone);
            pessoa.DataCadastro = DateTime.Now;
            pessoa.IdSexo = request.IdSexo;
            pessoa.Telefone = FunctionsHelper.RemovePontosTracosTelefone(pessoa.Telefone);
            // Caso não tenha email
            pessoa.ValorEmail = string.IsNullOrWhiteSpace(pessoa.ValorEmail?.EnderecoEmail)
                ? new ValorEmail($"nadaconsta{cpf}@email.com")
                : pessoa.ValorEmail;

            // 3. Validação de CPF
            if (!FunctionsHelper.ValidadorCPF(cpf))
                throw new ApplicationException("CPF inválido.");

            // 4. Validação com FluentValidation
            var validator = new PessoaFisicaValidator();
            var result = validator.Validate(pessoa);

            if (!result.IsValid) 
                throw new ValidationException(result.Errors);

            // 5. Consulta única para verificar duplicidades
            if (await unitOfWork.PessoaRepository.CpfInUseAsync(cpf))
                throw new InvalidOperationException("CPF já cadastrado.");

            if (!string.IsNullOrEmpty(rg) &&
                await unitOfWork.PessoaRepository.RgInUseAsync(rg))
                throw new InvalidOperationException("RG já cadastrado.");

            if (await unitOfWork.PessoaRepository.EmailInUseAsync(pessoa.ValorEmail.EnderecoEmail))
                throw new InvalidOperationException("Email já cadastrado.");

            // 6. Adiciona Pessoa
            await unitOfWork.PessoaRepository.AddAsync(pessoa);

            // salva para gerar Id
            await unitOfWork.CommitAsync();

            // 7. Adiciona Endereço
            var endereco = mapper.Map<Endereco>(request);

            endereco.IdPessoa = pessoa.Id;
            endereco.Cep = FunctionsHelper.RemovePontosTracos(endereco.Cep);
            endereco.Complemento ??= "";

            await unitOfWork.EnderecoRepository.AddAsync(endereco);

            // 8. Salva no banco
            await unitOfWork.CommitAsync();

            // 9. Retorno
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
