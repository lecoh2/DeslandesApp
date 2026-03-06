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
                //definindo o tipo de autenticação da API como JWT - JSON WEB TOKENS
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    //chave secreta para validar os tokens da API
                    IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(JwtTokenSettings.SecretKey))
                };
            });

        }
        #endregion
    }
}
