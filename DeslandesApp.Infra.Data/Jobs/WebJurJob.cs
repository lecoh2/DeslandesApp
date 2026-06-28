using DeslandesApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
namespace DeslandesApp.Infra.Data.Jobs
{
    public class WebJurJob
    {
        private readonly IWebJurService _webJurService;

        public WebJurJob(IWebJurService webJurService)
        {
            _webJurService = webJurService;
        }

        [DisableConcurrentExecution(600)]
        public async Task ImportarPublicacoes()
        {
            await _webJurService.ImportarPublicacoesAsync();
        }

        public async Task SincronizarProcessos()
        {
            await _webJurService.SincronizarProcessosMonitoradosAsync();
        }
    }
}
