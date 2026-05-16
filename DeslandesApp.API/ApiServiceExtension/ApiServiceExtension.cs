using DeslandesApp.API.Services;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Services;

public static class ApiServiceExtension
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services)
    {
        services.AddSignalR();

        services.AddScoped<
            INotificacaoTempoRealService,
            NotificacaoTempoRealService>();
        services.AddScoped<INotificacaoService, NotificacaoService>();

        return services;
    }
}