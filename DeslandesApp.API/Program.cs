using DeslandesApp.API.Configurations;
using DeslandesApp.API.Middlewares;
using DeslandesApp.Domain.Extensions;
using DeslandesApp.Infra.Data.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDomainService();
// Configuração de segurança, Cors e outras dependências
SwaggerConfiguration.Configure(builder.Services);
DependencyInjectionConfiguration.Configure(builder.Services);
JwtConfiguration.Configure(builder.Services);
CorsConfiguration.Configure(builder.Services);
//Métodos de extensão 

var app = builder.Build();
//Middlewares 
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
//Swagger 
app.UseSwagger();
app.UseSwaggerUI();

//Scalar 
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

app.UseAuthorization();

app.MapControllers();

app.Run();
