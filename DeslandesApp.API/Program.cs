using DeslandesApp.API.Configurations;
using DeslandesApp.API.Middlewares;
using DeslandesApp.Domain.Extensions;
using DeslandesApp.Infra.Data.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ===== Carregar appsettings.json e appsettings.{Ambiente}.json =====
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Log pra confirmar qual ambiente está sendo usado
Console.WriteLine($">>> Ambiente atual: {builder.Environment.EnvironmentName}");

// ===== Add services =====
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// ===== Configurações de infraestrutura e banco =====
builder.Services.AddEntityFramework(builder.Configuration);

// ===== Serviços do Domain =====
builder.Services.AddDomainService(); // Interfaces e serviços do Domain

// ===== Serviços concretos e repositórios (Infra) =====
DependencyInjectionConfiguration.Configure(builder.Services);

// ===== JWT, CORS, Swagger extras =====
JwtConfiguration.Configure(builder.Services);
CorsConfiguration.Configure(builder.Services);

// ===== Build app =====
var app = builder.Build();

// ===== Middlewares =====
app.UseMiddleware<ExceptionMiddleware>();

// ===== Swagger =====
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProconApp API V1");
});

// ===== Scalar API =====
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

// ===== Autorização e CORS =====
app.UseAuthorization();
app.UseCors(CorsConfiguration.PolicyName);

// ===== Map Controllers =====
app.MapControllers();

// ===== Run app =====
app.Run();

// ===== Para testes e WebApplicationFactory =====
public partial class Program { }
