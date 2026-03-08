using DeslandesApp.Domain.Contracts.Security;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Mappings;
using DeslandesApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            services.AddAutoMapper(map => map.AddProfile
(typeof(ProfileMap)));

          //services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<ISetorService, SetorService>();
            services.AddTransient<INivelServices, NiveisService>();
            //services.AddTransient<IGrupoNiveisServices, GrupoNiveisService>();
            //services.AddTransient<IGrupoSetoresService, GrupoSetoresService>()
            

            return services;
        }
    }
}
