using DeslandesApp.Domain.Contracts.Security;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Infra.Data.Repositories;
using DeslandesApp.Infra.Security.Services;

namespace DeslandesApp.API.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
           //ervices.AddTransient<IPessoaRepository, PessoaRepository>();
        }
    }
}