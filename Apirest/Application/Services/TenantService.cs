using Application.Interface.Repository;
using Application.Interface.Service;
using Domain.Entities;

namespace Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public Task<Tenant?> GetTenantByIdAsync(string tenantId)
        {
            if (tenantId == null)
                throw new Exception("Tenant no puede ser Nulo");

            return _tenantRepository.GetTenantByIdAsync(tenantId);
        }
    }
}
