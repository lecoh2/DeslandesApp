using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
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
        public Task<UsuariosResponse> AdicionarAsync(UsuariosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<UsuariosResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<UsuariosResponse> Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuariosResponse> Modificar(Guid id, UsuariosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UsuariosResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
