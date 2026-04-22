using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class HistoricoGeralService : IHistoricoGeralService
    {
        private readonly IUnitOfWork unitOfWork;

        public HistoricoGeralService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task RegistrarAsync(
            TipoEntidade entidade,
            Guid entidadeId,
            Guid? usuarioId,
            object dadosAntes,
            object dadosDepois,
            string? observacao = null)
        {
            var historico = new HistoricoGeral
            {
                Entidade = entidade,
                EntidadeId = entidadeId,
                UsuarioId = usuarioId,
                DataAlteracao = DateTime.Now,
                Observacao = observacao,
                DadosAntes = JsonConvert.SerializeObject(dadosAntes),
                DadosDepois = JsonConvert.SerializeObject(dadosDepois)
            };

            await unitOfWork.HistoricoGeralRepository.AddAsync(historico);
        }
        public async Task<List<HistoricoGeral>> ObterAsync(TipoEntidade entidade, Guid entidadeId)
        {
            return await unitOfWork.HistoricoGeralRepository
                .ObterPorEntidadeAsync(entidade, entidadeId);
        }
    }
}
