using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Infra.Data.ExternalServices;
using DeslandesApp.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.InfrastructureExtension
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITribunalClient, TribunalClient>();
            services.AddScoped< IWebJurPublicacaoRepository, WebJurPublicacaoRepository>();
            return services;
        }
    }
}
