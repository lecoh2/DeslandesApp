using AutoMapper;
using DeslandesApp.Domain.Contracts.Security;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
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

          
            usuario.Senha = CryptoHelper.SHA256Encrypt(usuario.Senha);
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
    AutenticarUsuarioRequest request, string ip, string userAgent)

        {
            if (request == null)
                throw new ApplicationException("Requisição inválida");
            // Delay aleatório para mitigar timing attacks / brute force
            var rnd = new Random();
            await Task.Delay(rnd.Next(500, 1001)); // 500..1000 ms

            await unitOfWork.BeginTransactionAsync();
            try
            {
                // 1) Buscar usuário apenas pelo login (sem senha)
                var usuario = await unitOfWork.UsuarioRepository.GetUsuarioByLoginAsync(request.Login?.Trim());

                // 2) Se o usuário não existe -> registrar tentativa em FailedLoginAttempt (sem FK) e retornar genérico
                if (usuario == null)
                {
                    var failedAttempt = new FailedLoginAttempt
                    {
                        Id = Guid.NewGuid(),
                        IdUsuario = null,
                        Login = request.Login ?? string.Empty,
                        IpAcesso = ip,
                        UserAgent = userAgent,
                        DataHora = DateTime.UtcNow,
                        Mensagem = "Usuário não encontrado."
                    };

                    await unitOfWork.FailedLoginAttemptRepository.AddAsync(failedAttempt);
                    await unitOfWork.CommitAsync(); // persiste apenas o failedAttempt

                    throw new ApplicationException("Credenciais inválidas.");
                }

                // 3) Se o usuário estiver bloqueado, retorne mensagem específica (não tente gravar LoginHistory com FK nesta rota)
                if (usuario.Status == Status.Bloqueado)
                {
                    // opcional: registrar um failedAttempt sem FK para auditoria
                    var failedAttemptBlocked = new FailedLoginAttempt
                    {
                        Id = Guid.NewGuid(),
                        IdUsuario = usuario.Id,
                        Login = request.Login ?? string.Empty,
                        IpAcesso = ip,
                        UserAgent = userAgent,
                        DataHora = DateTime.UtcNow,
                        Mensagem = "Tentativa de login em conta bloqueada."
                    };

                    await unitOfWork.FailedLoginAttemptRepository.AddAsync(failedAttemptBlocked);
                    await unitOfWork.CommitAsync();

                    throw new ApplicationException("Conta bloqueada. Contate o administrador.");

                } // 4) Verifica a senha
                var senhaCriptografada = CryptoHelper.SHA256Encrypt(request.Senha);
                var senhaValida = usuario.Senha == senhaCriptografada;

                if (!senhaValida)
                {
                    // registrar LoginHistory (com FK — usuário existe)
                    var historicoFalha = new LoginHistory
                    {
                        Id = Guid.NewGuid(),
                        IdUsuario = usuario.Id,
                        DataHoraAcesso = DateTime.UtcNow,
                        IpAcesso = ip,
                        UserAgent = userAgent,
                        Sucesso = false,
                        Mensagem = "Falha ao autenticar: senha incorreta."
                    };
                    await unitOfWork.LoginHistoryRepository.AddAsync(historicoFalha);

                    // registrar FailedLoginAttempt (sem dependência de FK para auditoria e contagem)
                    var failedAttempt = new FailedLoginAttempt
                    {
                        Id = Guid.NewGuid(),
                        IdUsuario = usuario.Id,
                        Login = request.Login ?? string.Empty,
                        IpAcesso = ip,
                        UserAgent = userAgent,
                        DataHora = DateTime.UtcNow,
                        Mensagem = "Senha incorreta."
                    };
                    await unitOfWork.FailedLoginAttemptRepository.AddAsync(failedAttempt);

                    // persiste as tentativas
                    await unitOfWork.CommitAsync();

                    // 6) Verificar número de tentativas falhas e bloquear se >= 3
                    var totalFailed = await unitOfWork.FailedLoginAttemptRepository
                        .CountRecentFailedAttemptsByUserAsync(usuario.Id);

                    if (totalFailed >= 3)
                    {
                        usuario.Status = Status.Bloqueado;
                        usuario.DataAtualizacao = DateTime.UtcNow;
                        await unitOfWork.UsuarioRepository.UpdateAsync(usuario);

                        var bloqueioHistory = new LoginHistory
                        {
                            Id = Guid.NewGuid(),
                            IdUsuario = usuario.Id,
                            DataHoraAcesso = DateTime.UtcNow,
                            IpAcesso = ip,
                            UserAgent = userAgent,
                            Sucesso = false,
                            Mensagem = "Usuário bloqueado após múltiplas tentativas inválidas."
                        };
                        await unitOfWork.LoginHistoryRepository.AddAsync(bloqueioHistory);

                        await unitOfWork.CommitAsync();
                    }

                    // Mensagem genérica para o cliente
                    throw new ApplicationException("Credenciais inválidas.");
                }

                // 7) Se chegou aqui, senha válida -> login bem-sucedido
                var response = new AutenticarUsuarioResponse(
                  usuario.Id,
                  usuario.Login,
                  (usuario.GrupoNiveis ?? Enumerable.Empty<GrupoNiveis>())
                      .Select(gn => new NivelResponse(
                          gn.Niveis?.Id ?? Guid.Empty,
                          gn.Niveis?.NomeNivel ?? string.Empty
                      )).ToList(),
                  DateTime.UtcNow,
                  _jwtTokenService.GenerateExpirationDate(),
                  _jwtTokenService.GenerateToken(usuario),
                  "", // NomeUsuario
                  "", // Sexo
                  "", // Foto
                  ip  // IpAcesso
              );


                // 8) Registrar LoginHistory (sucesso)
                var loginSucesso = new LoginHistory
                {
                    Id = Guid.NewGuid(),
                    IdUsuario = usuario.Id,
                    IpAcesso = ip,
                    UserAgent = userAgent,
                    DataHoraAcesso = DateTime.UtcNow,
                    Sucesso = true,
                    Mensagem = "Login efetuado com sucesso."
                };
                await unitOfWork.LoginHistoryRepository.AddAsync(loginSucesso);

                // 9) Limpar tentativas falhas do usuário (opcional, mantém histórico mas marca/limpa)
                await unitOfWork.FailedLoginAttemptRepository.ClearFailedAttemptsForUserAsync(usuario.Id);

                await unitOfWork.CommitAsync();

                return response;
            }
            catch (ApplicationException)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                throw new ApplicationException("Erro interno no servidor.", ex);
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
