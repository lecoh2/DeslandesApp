using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IBaseRepository<Pessoa,Guid>
    {
        Task<bool> CpfInUseAsync(string cpf);
        // Task<Pessoa> ObterPorCpfAsync(string cpf);
        Task<bool> EmailInUseAsync(string email);
        Task<bool> RgInUseAsync(string cpf);
        Task<PessoaFisica> GetByCpfAsync(string cpf);
        Task<bool> CnpjInUseAsync(string cnpj);
        Task<bool> IncricaoEstadualInUseAsync(string incricaoEstadual);
        Task<PageResult<PessoaFisicaPaginacaoResponse>> PessoaFisicaComPaginacaoAsync(
     int pageNumber, int pageSize, string? searchTerm = null);
        Task<PageResult<PessoaJuridicaPaginacaoResponse>> ConsultarPessoaJuridicaComPaginacaoAsync(
    int pageNumber, int pageSize, string? searchTerm = null);
        Task<PessoaFisica> ConsultarPessoasFisicasComIdRelacionamentosAsync(Guid idPessoa);
        Task<PessoaJuridica> ConsultarPessoasJuridicasComIdRelacionamentosAsync(Guid idPessoa);
    }
}
