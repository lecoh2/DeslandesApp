using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<List<PessoaResumoResponse>> ConsultarResumoAsync(string? termo = null);
    }
}
