using DeslandesApp.API.Configurations;
using DeslandesApp.API.Middlewares;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Extensions;
using DeslandesApp.Infra.Data.Extensions;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ===== Carregar appsettings =====
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

Console.WriteLine($">>> Ambiente atual: {builder.Environment.EnvironmentName}");

// ===== Services =====
builder.Services.AddHttpContextAccessor();

// Adiciona controllers e exige usuário autenticado por padrão
builder.Services.AddControllers(config =>
{
    var policy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter(policy));
});

// ===== Swagger / OpenAPI =====
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DeslandesApp API",
        Version = "v1",
        Description = "API REST .NET com EntityFramework"
    });

    // Configuração JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT assim: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// ===== Entity Framework / Infra =====
builder.Services.AddEntityFramework(builder.Configuration);
DependencyInjectionConfiguration.Configure(builder.Services);

// ===== Domain Services =====
builder.Services.AddDomainService();

// ===== JWT + CORS =====
JwtConfiguration.Configure(builder.Services);
CorsConfiguration.Configure(builder.Services);

// ===== Hangfire =====
builder.Services.AddHangfire(config =>
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("DeslandesApp")));

builder.Services.AddHangfireServer();

var app = builder.Build();

// ===== Developer / Middleware =====
app.UseDeveloperExceptionPage();
app.UseMiddleware<ExceptionMiddleware>();

// ===== Swagger =====
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeslandesApp API V1");
    c.RoutePrefix = string.Empty; // Swagger na raiz: http://localhost:5000/
});

// ===== Hangfire Dashboard =====
app.UseHangfireDashboard("/hangfire");

// ===== Pipeline =====
app.UseRouting();
app.UseCors(CorsConfiguration.PolicyName);

app.UseAuthentication(); // ✅ JWT
app.UseAuthorization();

// ===== Controllers =====
app.MapControllers();

// ===== Jobs Hangfire (Background) =====
RecurringJob.AddOrUpdate<IEventoService>(
    "atualizar-status-eventos",
    x => x.AtualizarStatusAutomatico(),
    Cron.Hourly
);
RecurringJob.AddOrUpdate<ITarefaService>(
    "atualizar-status-tarefas",
    x => x.AtualizarStatusTarefasAutomatico(),
    Cron.Hourly
);

// ===== Run =====
app.Run();

// ===== Para WebApplicationFactory (Testes) =====
public partial class Program { }