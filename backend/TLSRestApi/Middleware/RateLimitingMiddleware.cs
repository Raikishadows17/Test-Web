using Domain.Exceptions;

namespace TLSRestApi.Middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RateLimitingMiddleware> _logger;
        private static readonly Dictionary<string, (DateTime Timestamp, int Count)> _requestCounts = new();
        private readonly int _maxRequestsPerMinute = 100;
        private static readonly SemaphoreSlim _lock = new(1, 1);

        public RateLimitingMiddleware(RequestDelegate next,ILogger<RateLimitingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _lock.WaitAsync();

            try
            {
                var now = DateTime.UtcNow;
                var key = $"{context.Items["TenantId"]?.ToString()}:{now:yyyyMMddHHmm}";

                if(_requestCounts.TryGetValue(key,out var entry))
                {
                    if(entry.Count >= _maxRequestsPerMinute)
                    {
                        _logger.LogWarning("Rate limit exceeded for tenant {Key}", key);
                        throw new BusinessRuleException($"Limite de {_maxRequestsPerMinute} solicitudes por minuto excedido");
                    }                    
                        _requestCounts[key] = (entry.Timestamp, entry.Count + 1);
                }
                else
                {
                    _requestCounts[key] = (now, 1);

                    var keysToRemove = _requestCounts
                        .Where(kvp => (now - kvp.Value.Timestamp).TotalMinutes >= 2)
                        .Select(kvp => kvp.Key)
                        .ToList();

                    foreach (var k in keysToRemove)
                    {
                        _requestCounts.Remove(k);
                    }

                }

            }
            finally
            {
                _lock.Release();
            }
            await _next(context);

        }

    }
}
