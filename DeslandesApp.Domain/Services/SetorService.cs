using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class SetorService(IUnitOfWork unitOfWork, IMapper mapper) : ISetorService
    {
        public async  Task<SetorResponse> AdicionarAsync(SetorRequest request)
        {
            // Mapeia DTO -> Entidade
            var setor = mapper.Map<Setor>(request);

            // Normalização de dados
            setor.NomeSetor = setor.NomeSetor.Trim().ToLower();

            // Validação
            var validator = new SetorValidator();
            var result = validator.Validate(setor);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            // Consulta única para verificar duplicidade
            var any = await unitOfWork.SetorRepository.AnyAsync(n => n.NomeSetor.Equals(setor.NomeSetor));

            if (any)
                throw new InvalidOperationException("O nome do setor já está cadastrado.Tente outro.");


            await unitOfWork.SetorRepository.AddAsync(setor);

            return mapper.Map<SetorResponse>(setor);
        }
        public Task<SetorResponse> ModificarAsync(Guid id, SetorRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<PageResult<SetorResponse>> ConsultarAsync(int pageNumber, int pageSize, string? serchTerms = null)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0 || pageSize > 25) pageSize = 25;

            var pageResult = await unitOfWork.SetorRepository.GetAllAsync(pageNumber, pageSize);

            var response = new PageResult<SetorResponse>
            {
                Items = mapper.Map<List<SetorResponse>>(pageResult.Items),
                PageNumber = pageResult.PageNumber,
                PageSize = pageResult.PageSize,
                TotalCount = pageResult.TotalCount
            };
            return response;
        }
        public Task<SetorResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<SetorResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }  
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<PageResult<SetorResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<SetorResponse>> ConsultarPaginacaoAsync(int pageNumber, int pageSize, string? serchTerm = null)
        {
            throw new NotImplementedException();
        }
    }
}
