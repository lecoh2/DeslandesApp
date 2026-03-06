using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.ValueObjects
{
    public sealed class ValorEmail
    {
        public string? EnderecoEmail { get; private set; }
        //Construtor reservado para o ValueObject 
        protected ValorEmail() { }
        //Construtor público para criar uma instância de Email 
        public ValorEmail(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentNullException("Email é obrigatório.");
            if (!IsValid(endereco))
                throw new ArgumentNullException("Email inválido.");
            EnderecoEmail = endereco.ToLower();
        }
        private bool IsValid(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }
        public override string ToString() => EnderecoEmail ?? string.Empty;
    }
}

