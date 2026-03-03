using Domain.Common;
using Domain.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
                NotFoundException notFound => (StatusCodes.Status404NotFound, Result<object>.Failure(notFound.Message)),
                KeyNotFoundException keyNotFound => (StatusCodes.Status404NotFound, Result<object>.Failure(keyNotFound.Message)),
                ValidationException validation => (StatusCodes.Status400BadRequest, Result<object>.Failure(validation.Errors)),
                
                DbUpdateException dbEx when dbEx.InnerException is SqlException sqlEx => sqlEx.Number switch
                {
                    547 => (StatusCodes.Status409Conflict, Result<object>.Failure("Referencia a un registro que no existe.")),
                    2601 or 2627 => (StatusCodes.Status409Conflict, Result<object>.Failure("Ya existe un registro con ese valor único.")),
                    515 => (StatusCodes.Status400BadRequest, Result<object>.Failure("Un campo requerido no fue proporcionado.")),
                    8152 => (StatusCodes.Status400BadRequest, Result<object>.Failure("Un valor excede la longitud permitida.")),
                    _ => (StatusCodes.Status500InternalServerError, Result<object>.Failure(
                        _env.IsDevelopment() ? sqlEx.Message : "Error de base de datos."))
                },
                
                SqlException sqlEx => sqlEx.Number switch
                {
                    547 => (StatusCodes.Status409Conflict, Result<object>.Failure("Referencia a un registro que no existe.")),
                    2601 or 2627 => (StatusCodes.Status409Conflict, Result<object>.Failure("Ya existe un registro con ese valor único.")),
                    515 => (StatusCodes.Status400BadRequest, Result<object>.Failure("Un campo requerido no fue proporcionado.")),
                    8152 => (StatusCodes.Status400BadRequest, Result<object>.Failure("Un valor excede la longitud permitida.")),
                    _ => (StatusCodes.Status500InternalServerError, Result<object>.Failure(
                        _env.IsDevelopment() ? sqlEx.Message : "Error de base de datos."))
                },

                BusinessRuleException businessRule => (StatusCodes.Status400BadRequest, Result<object>.Failure(businessRule.Message)),
                InvalidOperationException invalidOperation => (StatusCodes.Status403Forbidden, Result<object>.Failure(invalidOperation.Message)),
                UnauthorizedAccessException unauthorizedAccess => (StatusCodes.Status401Unauthorized, Result<object>.Failure(unauthorizedAccess.Message)),
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
