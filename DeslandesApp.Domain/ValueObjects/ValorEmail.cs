using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.ValueObjects
{
    public sealed class ValorEmail : IEquatable<ValorEmail>
    {
        public string? EnderecoEmail { get; private set; }

        protected ValorEmail() { }

        public ValorEmail(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("Email é obrigatório.");

            EnderecoEmail = endereco.ToLower();
        }

        public bool Equals(ValorEmail? other)
        {
            if (other is null) return false;
            return EnderecoEmail == other.EnderecoEmail;
        }

        public override bool Equals(object? obj)
            => Equals(obj as ValorEmail);

        public override int GetHashCode()
            => EnderecoEmail?.GetHashCode() ?? 0;

        public override string ToString() => EnderecoEmail ?? string.Empty;
    }

}

