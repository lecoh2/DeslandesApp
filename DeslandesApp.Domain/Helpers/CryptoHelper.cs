using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Helpers
{
    public class CryptoHelper
    {
        public static string SHA256Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("O valor não pode ser nulo ou vazio", nameof(value));
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] valueBytes = Encoding.UTF8.GetBytes(value);
                byte[] hasByte = sha256.ComputeHash(valueBytes);
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hasByte)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }
                return hashStringBuilder.ToString();
            }
        }
    }
}
