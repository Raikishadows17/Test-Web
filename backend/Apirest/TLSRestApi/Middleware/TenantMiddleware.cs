using Application.Interface.Repository;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using TLSRestApi.Attributes;


namespace Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;        

        public TenantMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {            
            var endpoint = context.GetEndpoint();
            var skipByAttribute = endpoint?.Metadata?.GetMetadata<SkipTenantValidationAttribute>() != null;
            
            if (skipByAttribute)
            {
                context.Items["TenantId"] = null;
                await _next(context);
                return;
            }

            try {
                if (context.Request.Headers.TryGetValue("TenantId", out var tenantId))
                {
                    var tenantRepository = context.RequestServices.GetRequiredService<ITenantRepository>();
                    context.Items["Tenant"] = await tenantRepository.GetTenantByIdAsync(tenantId.ToString());
                    await _next(context);
                }
                else
                    throw new Exception("No se envió el Tenant");
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
