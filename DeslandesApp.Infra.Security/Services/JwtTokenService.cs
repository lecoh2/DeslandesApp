using DeslandesApp.Domain.Contracts.Security;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Security.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Security.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            //capturando a chave para assinar o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtTokenSettings.SecretKey);

            //gerando o conteudo do token
            var tokenDescritor = new SecurityTokenDescriptor
            {
                //identificação do usuário autendicadoteste
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString())
                }),
                //data de expiração do token
                Expires = DateTime.UtcNow.AddHours(JwtTokenSettings.ExpirationInHours),
                //criptografando a chave para assinatura do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //gerando e retornando o token
            var token = tokenHandler.CreateToken(tokenDescritor);
            return tokenHandler.WriteToken(token);
        }
        public DateTime GenerateExpirationDate()
        {
            return DateTime.UtcNow.AddHours
            (JwtTokenSettings.ExpirationInHours);
        }

    }
}