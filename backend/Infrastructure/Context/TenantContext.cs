using Application.Interface.Context;
using Application.Interface.Repository;
using Domain.Entities;

namespace Infrastructure.Context
{
    public class TenantContext : ITenantContext
    {
        private Tenant _tenant;
        private readonly ITenantRepository _tenantRepository;

        public TenantContext(Tenant tenant)
        {
            _tenant = tenant;
        }

        public Tenant GetTenant()
        {
            if(string.IsNullOrEmpty(_tenant?.TenantKeyName))
                throw new Exception("Tenant no establecido en el contexto.");
            
            return _tenant;
        }
    }
}
