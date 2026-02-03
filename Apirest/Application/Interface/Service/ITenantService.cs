using Domain.Entities;

namespace Application.Interface.Service
{
    public interface ITenantService
    {
        Task<Tenant?> GetTenantByIdAsync(string tenantId);
    }
}
