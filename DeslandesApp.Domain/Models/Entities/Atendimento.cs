using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Atendimento : BaseEntity
    {
        public string Assunto { get; set; } = string.Empty;
        public string Registro { get; set; } = string.Empty; // conteúdo ou observações
        public Etiqueta Etiqueta { get; set; } 

        // Processo relacionado
        public Guid? ProcessoId { get; set; }
        public Processo? Processo { get; set; }

        // Clientes do atendimento (1:N via tabela de junção)
        public List<GrupoAtendimentoCliente> GrupoClientes { get; set; } = new List<GrupoAtendimentoCliente>();

    }
}

