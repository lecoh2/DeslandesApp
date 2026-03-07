using AutoMapper;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
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
    public class UsuarioService(IUnitOfWork unitOfWork, IMapper mapper) : IUsuarioService
    {

        public async Task<UsuariosResponse> AdicionarAsync(UsuariosRequest request)
        {
            // Mapeia DTO -> Entidade
            var usuario = mapper.Map<Usuario>(request);

            // Normalização de dados
            usuario.Login = usuario.Login.Trim().ToLower();
            usuario.ValorEmail = usuario.ValorEmail;
            usuario.NomeUsuario = usuario.NomeUsuario.Trim();
          
            usuario.DataCadastro = DateTime.Now;
            usuario.Status = Status.Ativo;
            // Validação
            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);
            usuario.Senha = CryptoHelper.SHA256Encrypt(usuario.Senha);
            // Consulta única para verificar duplicidade
            var existente = await unitOfWork.UsuarioRepository.GetByAsync(u =>
                u.NomeUsuario == usuario.NomeUsuario ||
                u.Login == usuario.Login ||
                u.ValorEmail == usuario.ValorEmail);

            if (existente != null)
            {
                if (existente.NomeUsuario == usuario.NomeUsuario)
                    throw new InvalidOperationException("Nome de usuário já utilizado.");

                if (existente.Login == usuario.Login)
                    throw new InvalidOperationException("Login já utilizado.");

                if (existente.ValorEmail == usuario.ValorEmail)
                    throw new InvalidOperationException("E-mail já utilizado.");
            }
            await unitOfWork.UsuarioRepository.AddAsync(usuario);
            // salva para gerar o Id
            await unitOfWork.CommitAsync();
            // Adiciona usuário
            #region 7. Adicionar vínculos de grupo de acesso e níveis
            foreach (var grupos in request.GrupoSetor)
            {
                var grupoSetores = new GrupoSetores
                {
                    IdUsuario = usuario.Id,
                    IdSetor = grupos.IdSetor,
                   
                };
                await unitOfWork.GrupoSetoresRepository.AddAsync(grupoSetores);
            }
                ;
            foreach (var grupos in request.GrupoNivel)
            {
                var grupoNiveis = new GrupoNiveis
                {
                    IdUsuario = usuario.Id,
                    IdNivel = grupos.IdNivel,
                 
                };
                await unitOfWork.GrupoNiveisRepository.AddAsync(grupoNiveis);
            }
                ;
            #endregion
         

            // Salva no banco
            await unitOfWork.CommitAsync();

            // Retorno
            return mapper.Map<UsuariosResponse>(usuario);
        }
    
   

        public Task<PageResult<UsuariosResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
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
