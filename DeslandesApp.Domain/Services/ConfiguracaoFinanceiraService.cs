using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.ConfiguracaoFinanceira;
using DeslandesApp.Domain.Models.Dtos.Responses.ConfiguracaoFinanceira;
using DeslandesApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class ConfiguracaoFinanceiraService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : IConfiguracaoFinanceiraService
    {
        public async Task<ConfiguracaoFinanceiraResponse>
         ObterAsync()
        {
            var configuracao =
                await unitOfWork
                    .ConfiguracaoFinanceiraRepository
                    .ObterAsync();

            if (configuracao == null)
            {
                return new ConfiguracaoFinanceiraResponse
                {
                    MetaMensal = 0,
                    MetaAnual = 0
                };
            }

            return mapper.Map<ConfiguracaoFinanceiraResponse>(
                configuracao);
        }

        public async Task<ConfiguracaoFinanceiraResponse>
    SalvarAsync(
        ConfiguracaoFinanceiraRequest request)
        {
            var configuracao =
                await unitOfWork
                    .ConfiguracaoFinanceiraRepository
                    .ObterAsync();

            if (configuracao == null)
            {
                configuracao =
                    mapper.Map<ConfiguracaoFinanceira>(
                        request);

                await unitOfWork
                    .ConfiguracaoFinanceiraRepository
                    .AdicionarAsync(configuracao);
            }
            else
            {
                configuracao.MetaMensal =
                    request.MetaMensal;

                configuracao.MetaAnual =
                    request.MetaAnual;

                unitOfWork
                    .ConfiguracaoFinanceiraRepository
                    .Atualizar(configuracao);
            }

            await unitOfWork.CommitAsync();

            return mapper.Map<
                ConfiguracaoFinanceiraResponse>(
                    configuracao);
        }
    }
}
