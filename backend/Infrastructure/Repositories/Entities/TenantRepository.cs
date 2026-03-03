using Domain.Entities;
using Application.Interface.Repository;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories.Entities
{
    public class TenantRepository : ITenantRepository
    {
        private readonly IConfiguration _configuration;

        public TenantRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        Dictionary<string, Tenant> tenants = new Dictionary<string, Tenant>()
        {
            { "Valmarq", new Tenant {TenantName = "Valmarq",TenantKeyName = "ValmarqDBConeectionString" ,Active = true } },
            { "tenant2", new Tenant {TenantName = "Tenant Two" ,TenantKeyName = "Tenant2DBConnectionString"  ,Active = true } }
        };

        public Task<Tenant?> GetTenantByIdAsync(string tenantName)
        {
            if (!tenants.TryGetValue(tenantName, out Tenant? tenant))
                throw new UnauthorizedAccessException("Tenant no registrado");                   
                
            if(string.IsNullOrEmpty(_configuration[tenant.TenantKeyName]))
                throw new Exception("Cadena de conexion no encontrada para el tenant especificado");

            if (tenant.Active == false)
                throw new UnauthorizedAccessException($"El Tenant '{tenantName}' proporcionado no está activo.");

            //tenant.DatabaseConnectionString = _configuration.GetConnectionString(tenant.TenantKeyName) ?? string.Empty;
            tenant.DatabaseConnectionString = _configuration[tenant.TenantKeyName] ?? string.Empty;

            return Task.FromResult<Tenant?>(tenant);
                
        }

    }
}
