using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Infra.Data.Contexts;
using DeslandesApp.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Extensions
{
    /// <summary> 
    /// Classe de extensão para configurar as injeções de dependência 
    /// do Entity Framework. 
    /// </summary> 
    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework (this IServiceCollection services,IConfiguration configuration)
        {
            //ler a connectionstring do banco de dados 
            var connectionString = configuration
                                    .GetConnectionString("DeslandesApp");

            //injetar as configurações da classe DataContext 
            services.AddDbContext<DataContext>(options
                                                => options.UseSqlServer(connectionString));
            //Injeção de dependência do UnitOfWork 
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
