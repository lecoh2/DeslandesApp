using DeslandesApp.Domain.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace DeslandesApp.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse();

            switch (ex)
            {
                // =========================
                // FLUENT VALIDATION
                // =========================
                case ValidationException validationEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    response = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Erros de validação encontrados.",
                        Errors = validationEx.Errors.Select(e => new ValidationError
                        {
                            Campo = e.PropertyName,
                            Erro = e.ErrorMessage
                        }).ToList()
                    };
                    break;

                // =========================
                // BUSINESS RULE (SUA REGRA PRINCIPAL)
                // =========================
                case BusinessException businessEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    response = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = businessEx.Message
                    };
                    break;

                // =========================
                // NOT FOUND
                // =========================
                case KeyNotFoundException notFoundEx:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                    response = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = notFoundEx.Message
                    };
                    break;

                // =========================
                // OUTROS ERROS DE NEGÓCIO GENÉRICOS
                // =========================
                case InvalidOperationException invalidEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    response = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = invalidEx.Message
                    };
                    break;

                case ApplicationException appEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    response = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = appEx.Message
                    };
                    break;

                // =========================
                // ERRO GENÉRICO
                // =========================
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    response = new ErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Erro inesperado no servidor."
                    };

                    Console.WriteLine(ex);
                    break;
            }

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            });

            await context.Response.WriteAsync(json);
        }
    }

    // =========================
    // RESPONSE PADRÃO
    // =========================
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public List<ValidationError>? Errors { get; set; }
    }

    public class ValidationError
    {
        public string Campo { get; set; } = string.Empty;
        public string Erro { get; set; } = string.Empty;
    }
}