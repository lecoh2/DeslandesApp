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

        public Task<PageResult<NivelResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

       

        public Task<NivelResponse> Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<NivelResponse> Modificar(Guid id, NivelRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<NivelResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
