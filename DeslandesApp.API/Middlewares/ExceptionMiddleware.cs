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
            var response = context.Response;

            var result = new ErrorResponse();

            switch (ex)
            {
                case ValidationException validationEx:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result.StatusCode = response.StatusCode;
                    result.Message = "Erros de validação encontrados.";
                    result.Errors = validationEx.Errors
                        .Select(e => new ValidationError
                        {
                            Campo = e.PropertyName,
                            Erro = e.ErrorMessage
                        })
                        .ToList();
                    break;

                case ApplicationException appEx:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result.StatusCode = response.StatusCode;
                    result.Message = appEx.Message;
                    break;

                case InvalidOperationException invalidOpEx:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result.StatusCode = response.StatusCode;
                    result.Message = invalidOpEx.Message;
                    break;

                case KeyNotFoundException keyEx:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    result.StatusCode = response.StatusCode;
                    result.Message = keyEx.Message;
                    break;

                //default:
                //    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //    result.StatusCode = response.StatusCode;
                //    result.Message = ex.Message; // mostrar erro real
                //    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result.StatusCode = response.StatusCode;
                    result.Message = ex.Message;

                    result.Errors = new List<ValidationError>
    {
        new ValidationError
        {
            Campo = "InnerException",
            Erro = ex.InnerException?.Message ?? "Sem inner exception"
        }
    };
                    break;
            }

            var json = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            await context.Response.WriteAsync(json);
        }
    }
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