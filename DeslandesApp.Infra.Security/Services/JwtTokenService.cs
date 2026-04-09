using DeslandesApp.Domain.Contracts.Security;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Security.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeslandesApp.Infra.Security.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            var key = Encoding.UTF8.GetBytes(JwtTokenSettings.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    // Use "unique_name" para NameClaimType
                    new Claim("unique_name", usuario.Id.ToString()),
                    new Claim("name", usuario.NomeUsuario),
                    new Claim("login", usuario.Login)
                }),
                Expires = DateTime.UtcNow.AddHours(JwtTokenSettings.ExpirationInHours),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public DateTime GenerateExpirationDate()
        {
            return DateTime.UtcNow.AddHours(JwtTokenSettings.ExpirationInHours);
        }
    }
}