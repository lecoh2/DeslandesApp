using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class FailedLoginAttempt
    {
       // public Guid IdFailedLoginAttempt { get; set; } = Guid.NewGuid();

        // Não obrigamos FK aqui para não violar constraints quando o usuário não existir
        public Guid? IdUsuario { get; set; }    // se existir usuário, armazenamos; se não existir, null
        public string Login { get; set; } = string.Empty; // o login informado
        public string? IpAcesso { get; set; }
        public string? UserAgent { get; set; }
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
        public string? Mensagem { get; set; }   // motivo: "senha incorreta" / "usuario inexistente" etc.
    }
}
