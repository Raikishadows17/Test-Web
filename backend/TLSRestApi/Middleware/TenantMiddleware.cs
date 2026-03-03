using Application.Interface.Context;
using Application.Interface.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using TLSRestApi.Attributes;


namespace Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ITenantContext _tenantContext;

        public TenantMiddleware(RequestDelegate next) {
            _next = next;            
        }

        public async Task InvokeAsync(HttpContext context)
        {            
            var endpoint = context.GetEndpoint();
            var skipByAttribute = endpoint?.Metadata?.GetMetadata<SkipTenantValidationAttribute>() != null;
            
            if (skipByAttribute)
            {
                context.Items["Tenant"] = null;
                await _next(context);
                return;
            }

            //try {
                if (!context.Request.Headers.TryGetValue("TenantId", out var tenantId))
                    throw new UnauthorizedAccessException("'TenantId' es requerido");

                var tenantRepository = context.RequestServices.GetRequiredService<ITenantRepository>();
                var tenant = await tenantRepository.GetTenantByIdAsync(tenantId.ToString());
                context.Items["Tenant"] = tenant;
                
                //Tenant? tenant = await tenantRepository.GetTenantByIdAsync(tenantId.ToString());

                await _next(context);

            //}catch (UnauthorizedAccessException)
            //{
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"{ ex.Message}", ex);
            //}
        }
    }
}
