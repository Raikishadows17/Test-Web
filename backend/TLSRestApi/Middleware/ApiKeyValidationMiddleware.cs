using TLSRestApi.Attributes;

namespace TLSRestApi.Middleware
{
    public class ApiKeyValidationMiddleware
    {

        public readonly RequestDelegate _next;
        public readonly ILogger<ApiKeyValidationMiddleware> _logger;
        public readonly IConfiguration _configuration;

        public ApiKeyValidationMiddleware(RequestDelegate next, ILogger<ApiKeyValidationMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var skipApiKey = endpoint?.Metadata?.GetMetadata<SkipApiKeyValidationAttribute>() != null;

            if (skipApiKey)
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey))
               throw new UnauthorizedAccessException("Falta API Key");
            

            var apiKey = _configuration["JwtSettings:ApiKey"];
            if (!apiKey.Equals(extractedApiKey))
            {
                throw new UnauthorizedAccessException("Cliente sin Autorizacion");
            }
            await _next(context);
        }

    }
}
