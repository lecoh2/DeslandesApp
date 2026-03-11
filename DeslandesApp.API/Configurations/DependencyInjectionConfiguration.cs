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

            // Repositórios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IInformacoesComplementaresRepository, InformacoesComplementaresRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<INivelRepository, NivelRepository>();

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}