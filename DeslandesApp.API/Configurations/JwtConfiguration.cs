using DeslandesApp.Infra.Security.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DeslandesApp.API.Configurations
{
    public class JwtConfiguration
    {
        #region Adicionando a política de autenticação do projeto
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthentication(auth =>
            {
                // Define JWT como esquema padrão
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    // Chave secreta da API
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.SecretKey)),

                    // Aqui dizemos ao ASP.NET qual claim usar como NameIdentifier
                    NameClaimType = "unique_name", // Agora Identity.Name ou HttpContext.User.FindFirst("unique_name") retorna o idUsuario
                    RoleClaimType = "role"        // opcional, caso use roles
                };
            });
        }
        #endregion
    }
}