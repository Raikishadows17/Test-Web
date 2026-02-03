using Domain.Common;
using Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace TLSRestApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger,IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context,Exception exception)
        {
            _logger.LogError(exception, $"Error: {exception.Message}");

            context.Response.ContentType = "application/json";

            var( statusCode, result) = exception switch
            {
                NotFoundException notFound => (StatusCodes.Status404NotFound, Result<Object>.Failure(notFound.Message)),
                Domain.Exceptions.ValidationException validation => (StatusCodes.Status400BadRequest, Result<object>.Failure(validation.Errors)),
                BusinessRuleException businessRule => (StatusCodes.Status400BadRequest, Result<object>.Failure(businessRule.Message)),
                InvalidOperationException invalidOperation => (StatusCodes.Status403Forbidden,Result<object>.Failure(invalidOperation.Message)),
                UnauthorizedAccessException _ => ( StatusCodes.Status401Unauthorized, Result<object>.Failure("No autorizado")),
                _ => (
                    StatusCodes.Status500InternalServerError,
                    Result<object>.Failure(
                        _env.IsDevelopment()
                            ? exception.Message
                            : "Error interno del servidor"
                    )
                )
            };

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
