using Microsoft.OpenApi.Models;

namespace DeslandesApp.API.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                // Configura a documentação da API
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DeslandesApp - Api para Sistema de Escritorio",
                    Description = "API REST .NET com EntityFramework e XUnit",
                    Version = "v3", // Corrigido para o formato OpenAPI
                    Contact = new OpenApiContact
                    {
                        Name = "Deslandes",
                        Email = "lecoh2@hotmail.com",
                        Url = new Uri("#")
                    }
                });

                // Adiciona a configuração de segurança (JWT)
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entre com o TOKEN JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // Exige a segurança (JWT) em todos os endpoints da API
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }
    }
}
