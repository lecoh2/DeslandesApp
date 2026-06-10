using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Commons
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();      
        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        // =========================
        // SOFT DELETE
        // =========================
        public bool Excluido { get; set; } = false;

        public DateTime? DataExclusao { get; set; }

        public Guid? UsuarioExclusaoId { get; set; }
        public Guid? UsuarioCadastroId { get; set; }
        public Guid?  UsuarioAtualizacaoId { get; set; }
        public Usuario UsuarioCadastro { get; set; }
    }
}
