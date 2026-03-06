namespace DeslandesApp.API.Configurations
{
    public class DependencyInjectionConfiguration
    {
        #region Adicionando as injeções de dependência do projeto
        public static void Configure(IServiceCollection services)
        {
            //services.AddTransient<IJwtTokenService, JwtTokenService>();
            //services.AddTransient<IFailedLoginAttemptRepository, FailedLoginAttemptRepository>();


            //// Registrar o IUSuarioRepository
            //services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            //// Registrar o IUsuarioDomainService
            //services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

            //// Registrar o IUSuarioRepository
            //services.AddTransient<ILoginHistoryRepository, LoginHistoryRepository>();
            //// Registrar o IUsuarioDomainService

            //// Registrar o ISexoRepository
            //services.AddTransient<ISexoRepository, SexoRepository>();
            //// Registrar o ISexoDomainService
            //services.AddTransient<ISexoDomainService, SexoDomainService>();
        }
        #endregion
    }
}