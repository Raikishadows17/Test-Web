using Domain.Entities;

namespace Application.Interface.Repository
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetTenantByIdAsync(string tenantId);
    }
}
