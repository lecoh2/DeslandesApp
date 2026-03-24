using Microsoft.OpenApi.Models;

namespace DeslandesApp.API.Configurations
{
    public class SwaggerConfiguration
    {       
            public static void Configure(IServiceCollection services)
            {
                services.AddSwaggerGen(options =>
                {
                    // Configura a documentação da API
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "DeslandesApp - API Sistema de Escritório",
                        Version = "v1",
                        Description = "API REST .NET com EntityFramework e JWT",
                        Contact = new OpenApiContact
                        {
                            Name = "Deslandes",
                            Email = "lecoh2@hotmail.com",
                            Url = new Uri("#")
                        }
                    });

                    // Configuração de segurança (JWT)
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Entre com o token JWT no formato: Bearer {seu_token}"
                    });

                    // Aplica JWT em todos os endpoints
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


