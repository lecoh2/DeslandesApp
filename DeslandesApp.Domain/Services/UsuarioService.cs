using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuario;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuario;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class UsuarioService(IUnitOfWork unitOfWork, IMapper mapper) : IUsuarioService
    {
        public Task<UsuarioResponse> AdicionarAsync(UsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<UsuarioResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> Modificar(Guid id, UsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
