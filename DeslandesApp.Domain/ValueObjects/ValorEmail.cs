//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace DeslandesApp.Domain.ValueObjects
//{
//    public sealed class ValorEmail : IEquatable<ValorEmail>
//    {
//        public string? EnderecoEmail { get; private set; }

//        protected ValorEmail() { }

//        public ValorEmail(string endereco)
//        {
//            if (string.IsNullOrWhiteSpace(endereco))
//                throw new ArgumentException("Email é obrigatório.");

//            EnderecoEmail = endereco.ToLower();
//        }

//        public bool Equals(ValorEmail? other)
//        {
//            if (other is null) return false;
//            return EnderecoEmail == other.EnderecoEmail;
//        }

//        public override bool Equals(object? obj)
//            => Equals(obj as ValorEmail);

//        public override int GetHashCode()
//            => EnderecoEmail?.GetHashCode() ?? 0;

//        public override string ToString() => EnderecoEmail ?? string.Empty;
//    }

//}

using System;
using System.Text.RegularExpressions;

namespace DeslandesApp.Domain.ValueObjects
{
    public sealed class ValorEmail : IEquatable<ValorEmail>
    {
        public string? EnderecoEmail { get; private set; }

        protected ValorEmail() { } // Necessário para EF Core

        public ValorEmail(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("Email é obrigatório.");

            endereco = endereco.Trim().ToLower();

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!regex.IsMatch(endereco))
                throw new ArgumentException("Email inválido.");

            EnderecoEmail = endereco;
        }

        public static ValorEmail Create(string email)
        {
            return new ValorEmail(email);
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

        public static bool operator ==(ValorEmail? left, ValorEmail? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(ValorEmail? left, ValorEmail? right)
        {
            return !(left == right);
        }

        public override string ToString() => EnderecoEmail ?? string.Empty;
    }
}