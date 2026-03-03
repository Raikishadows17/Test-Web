using Domain.Entities;
namespace Application.Interface.Context
{
    public interface ITenantContext
    {
        Tenant GetTenant();
    }
}
