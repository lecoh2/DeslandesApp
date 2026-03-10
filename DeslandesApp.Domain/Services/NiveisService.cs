using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace DeslandesApp.Domain.Services
{
    public class NiveisService(IUnitOfWork unitOfWork, IMapper mapper) : INivelServices
    {
        public async Task<NivelResponse> AdicionarAsync(NivelRequest request)
        {
            // Mapeia DTO -> Entidade
            var nivel = mapper.Map<Niveis>(request);

            // Normalização de dados
            nivel.NomeNivel = nivel.NomeNivel.Trim().ToLower();          

            // Validação
            var validator = new NivelValidator();
            var result = validator.Validate(nivel);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            // Consulta única para verificar duplicidade
             var any = await unitOfWork.NivelRepository.AnyAsync(n => n.NomeNivel.Equals(nivel.NomeNivel));

            if (any)
                throw new InvalidOperationException("O nome do Nível já está cadastrado.Tente outro."); 


            await unitOfWork.NivelRepository.AddAsync(nivel);

            return mapper.Map<NivelResponse>(nivel);
        }
        public Task<NivelResponse> ModificarAsync(Guid id, NivelUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<NivelResponse>> ConsultarAsync(int pageNumber, int pageSize , string? serchTerms = null)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0 || pageSize > 25) pageSize = 25;

            var pageResult = await unitOfWork.NivelRepository.GetAllAsync(pageNumber, pageSize);

            var response = new PageResult<NivelResponse>
            {
                Items = mapper.Map<List<NivelResponse>>(pageResult.Items),
                PageNumber = pageResult.PageNumber,
                PageSize = pageResult.PageSize,
                TotalCount = pageResult.TotalCount
            };
            return response;
        }       


        public Task<NivelResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<NivelResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<PageResult<NivelResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<NivelResponse>> ConsultarPaginacaoAsync(int pageNumber, int pageSize, string? serchTerm = null)
        {
            throw new NotImplementedException();
        }
        public async Task AdicionarNivelAsync(Guid idUsuario, Guid idNivel)
        {
            await unitOfWork.BeginTransactionAsync();

            var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(idUsuario);
            if (usuario is null)
                throw new ApplicationException("Usuário não encontrado.");

            var nivel = await unitOfWork.NivelRepository.GetByIdAsync(idNivel);
            if (nivel is null)
                throw new ApplicationException("Nível não encontrado.");

            var existeVinculo = await unitOfWork.GrupoNiveisRepository
                .ExistUsuarioNivelAsync(idUsuario, idNivel);

            if (existeVinculo != null)
                throw new ApplicationException("Este usuário já está vinculado a esse nível.");

            var grupoNivel = new GrupoNiveis
            {
                IdUsuario = idUsuario,
                IdNivel = idNivel
            };

            await unitOfWork.GrupoNiveisRepository.AddAsync(grupoNivel);

            await unitOfWork.CommitAsync();
        }
        public async Task RemoverNivelAsync(Guid idUsuario, Guid idNivel)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoNiveisRepository
                    .GetByIdUsuarioIdNivel(idUsuario, idNivel);

                if (entidade is null)
                    throw new ApplicationException("Vínculo entre usuário e nível não encontrado.");

                await unitOfWork.GrupoNiveisRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
