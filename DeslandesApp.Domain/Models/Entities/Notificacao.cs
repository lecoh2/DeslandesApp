using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Notificacao
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public Usuario Usuario { get; set; } // 🔥 ADD ISSO
        public bool Lida { get; set; }

        public DateTime DataCriacao { get; set; }

        // 🔥 NOVO: origem da notificação
        public TipoEntidade Tipo { get; set; }

        // 🔥 NOVO: link opcional
        public string? Link { get; set; }

        // 🔥 NOVO: referência (tarefa/evento/processo)
        public Guid? EntidadeId { get; set; }
    }
}
