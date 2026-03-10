using AutoMapper;
using DeslandesApp.Domain.Contracts.Security;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
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
    public class UsuarioService(IUnitOfWork unitOfWork, IMapper mapper, IJwtTokenService _jwtTokenService) : IUsuarioService
    {

        public async Task<UsuariosResponse> AdicionarAsync(UsuariosRequest request)
        {
            await unitOfWork.BeginTransactionAsync();
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
        public async Task<UsuariosResponse> ModificarAsync(Guid id, UsuarioUpdateRequest request)
        {
            var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(id);

            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            mapper.Map(request, usuario);

            if (!string.IsNullOrEmpty(request.Senha))
                usuario.Senha = CryptoHelper.SHA256Encrypt(request.Senha);
            usuario.Status = Status.Ativo;
            usuario.DataAtualizacao = DateTime.Now;


            await unitOfWork.UsuarioRepository.UpdateAsync(usuario);

            return mapper.Map<UsuariosResponse>(usuario);
        }
        public async Task<PageResult<UsuariosResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0 || pageSize > 25) pageSize = 25;

            var pageResult = await unitOfWork.UsuarioRepository.GetAllAsync(pageNumber, pageSize);

            var response = new PageResult<UsuariosResponse>
            {
                Items = mapper.Map<List<UsuariosResponse>>(pageResult.Items),
                PageNumber = pageResult.PageNumber,
                PageSize = pageResult.PageSize,
                TotalCount = pageResult.TotalCount
            };
            return response;
        }
        public async Task<UsuariosResponse?> ObterPorIdAsync(Guid id)
        {
            var usuario = await unitOfWork.UsuarioRepository.GetByAsync(u => u.Id == id);
            if (usuario == null)
                return null;
            return mapper.Map<UsuariosResponse>(usuario);
        }
        public async Task<UsuariosResponse> ExcluirAsync(Guid id)
        {
            var usuario = await unitOfWork.UsuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado, tente outro");
            await unitOfWork.UsuarioRepository.DeleteAsync(usuario);
            return mapper.Map<UsuariosResponse>(usuario);
        }
        public async Task<AutenticarUsuarioResponse> AutenticarUsuarioAsync(
 AutenticarUsuarioRequest request,
 string ip,
 string userAgent)
        {
            if (request == null)
                throw new ApplicationException("Requisição inválida.");

            // Delay aleatório para reduzir brute force
            var rnd = new Random();
            await Task.Delay(rnd.Next(500, 1001));

            await unitOfWork.BeginTransactionAsync();

            try
            {
                // 1️⃣ Buscar usuário
                var usuario = await unitOfWork.UsuarioRepository
                    .GetUsuarioByLoginAsync(request.Login?.Trim());

                // 2️⃣ Usuário não encontrado
                if (usuario == null)
                {
                    await unitOfWork.FailedLoginAttemptRepository.AddAsync(new FailedLoginAttempt
                    {
                        Id = Guid.NewGuid(),
                        Login = request.Login ?? string.Empty,
                        IpAcesso = ip,
                        UserAgent = userAgent,
                        DataHora = DateTime.UtcNow,
                        Mensagem = "Usuário não encontrado."
                    });

                    await unitOfWork.CommitAsync();

                    throw new ApplicationException("Credenciais inválidas.");
                }

                // 3️⃣ Conta bloqueada
                if (usuario.Status == Status.Bloqueado)
                {
                    await unitOfWork.FailedLoginAttemptRepository.AddAsync(new FailedLoginAttempt
                    {
                        Id = Guid.NewGuid(),
                        IdUsuario = usuario.Id,
                        Login = usuario.Login ?? "",
                        IpAcesso = ip,
                        UserAgent = userAgent,
                        DataHora = DateTime.UtcNow,
                        Mensagem = "Tentativa de login em conta bloqueada."
                    });

                    await unitOfWork.CommitAsync();

                    throw new ApplicationException("Conta bloqueada. Contate o administrador.");
                }

                // 4️⃣ Validar senha
                var senhaCriptografada = CryptoHelper.SHA256Encrypt(request.Senha);
                var senhaValida = usuario.Senha == senhaCriptografada;

                if (!senhaValida)
                {
                    await unitOfWork.LoginHistoryRepository.AddAsync(new LoginHistory
                    {
                        Id = Guid.NewGuid(),
                        IdUsuario = usuario.Id,
                        DataHoraAcesso = DateTime.UtcNow,
                        IpAcesso = ip,
                        UserAgent = userAgent,
                        Sucesso = false,
                        Mensagem = "Falha ao autenticar: senha incorreta."
                    });

                    await unitOfWork.FailedLoginAttemptRepository.AddAsync(new FailedLoginAttempt
                    {
                        Id = Guid.NewGuid(),
                        IdUsuario = usuario.Id,
                        Login = usuario.Login ?? "",
                        IpAcesso = ip,
                        UserAgent = userAgent,
                        DataHora = DateTime.UtcNow,
                        Mensagem = "Senha incorreta."
                    });

                    await unitOfWork.CommitAsync();

                    // 5️⃣ Verificar tentativas
                    var totalFailed = await unitOfWork
                        .FailedLoginAttemptRepository
                        .CountRecentFailedAttemptsByUserAsync(usuario.Id);

                    if (totalFailed >= 3)
                    {
                        usuario.Status = Status.Bloqueado;
                        usuario.DataAtualizacao = DateTime.UtcNow;

                        await unitOfWork.UsuarioRepository.UpdateAsync(usuario);

                        await unitOfWork.LoginHistoryRepository.AddAsync(new LoginHistory
                        {
                            Id = Guid.NewGuid(),
                            IdUsuario = usuario.Id,
                            DataHoraAcesso = DateTime.UtcNow,
                            IpAcesso = ip,
                            UserAgent = userAgent,
                            Sucesso = false,
                            Mensagem = "Usuário bloqueado após múltiplas tentativas inválidas."
                        });

                        await unitOfWork.CommitAsync();
                    }

                    throw new ApplicationException("Credenciais inválidas.");
                }

                // 6️⃣ Login sucesso

                var niveis = (usuario.GrupoNiveis ?? Enumerable.Empty<GrupoNiveis>())
                    .Select(gn => new NivelResponse(
                        gn.Niveis?.Id ?? Guid.Empty,
                        gn.Niveis?.NomeNivel ?? string.Empty))
                    .ToList();

                var setores = (usuario.GrupoSetores ?? Enumerable.Empty<GrupoSetores>())
                    .Select(gs => new SetorResponse(
                        gs.Setor?.Id ?? Guid.Empty,
                        gs.Setor?.NomeSetor ?? string.Empty))
                    .ToList();

                var response = new AutenticarUsuarioResponse(
                    usuario.Id,
                    usuario.Login ?? "",
                    niveis,
                    setores,
                    DateTime.UtcNow,
                    _jwtTokenService.GenerateExpirationDate(),
                    _jwtTokenService.GenerateToken(usuario),
                    usuario.NomeUsuario ?? "",
                    usuario.Fotos?.FotoNome ?? "",
                    ip
                );

                // 7️⃣ Registrar login sucesso
                await unitOfWork.LoginHistoryRepository.AddAsync(new LoginHistory
                {
                    Id = Guid.NewGuid(),
                    IdUsuario = usuario.Id,
                    DataHoraAcesso = DateTime.UtcNow,
                    IpAcesso = ip,
                    UserAgent = userAgent,
                    Sucesso = true,
                    Mensagem = "Login efetuado com sucesso."
                });

                // 8️⃣ Limpar tentativas falhas
                await unitOfWork.FailedLoginAttemptRepository
                    .ClearFailedAttemptsForUserAsync(usuario.Id);

                await unitOfWork.CommitAsync();

                return response;
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<PageResult<UsuarioPaginacaoResponse>> ConsultarUsuariosComPaginacaoAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null)
        {
            var paged = await unitOfWork.UsuarioRepository
                .GetUsuariosComPaginadoAsync(pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<UsuarioPaginacaoResponse>
                {
                    Items = new List<UsuarioPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }


    }
}
