using Domain.Entities;
using Application.Interface.Repository;

namespace Infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        Dictionary<string, Tenant> tenants = new Dictionary<string, Tenant>()
        {
            { "Valmarq", new Tenant { TenantId = "Valmarq", TenantName = "Valmarq" } },
            { "tenant2", new Tenant { TenantId = "tenant2", TenantName = "Tenant Two" } }
        };

        public Task<Tenant?> GetTenantByIdAsync(string tenantId)
        {
            if (tenants.TryGetValue(tenantId, out Tenant? tenant))
                return Task.FromResult<Tenant?>(tenant);
            else
                throw new Exception("Tenant no registrado");
        }
    }
}
