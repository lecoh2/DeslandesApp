using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Helpers
{
    public static class StatusKanbanHelper
    {
        public static string ObterNome(StatusGeralKanban status)
            => status.ToString().Replace("_", " ");

        public static string ObterCor(StatusGeralKanban status)
        {
            return status switch
            {
                StatusGeralKanban.A_Fazer => "#95a5a6",
                StatusGeralKanban.Em_Andamento => "#3498db",
                StatusGeralKanban.Concluido => "#2ecc71",
                _ => "#7f8c8d"
            };
        }
    }
}
