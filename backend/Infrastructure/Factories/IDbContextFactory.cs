using Infrastructure.DataContext;

namespace Infrastructure.Factories
{
    public interface IDbContextFactory
    {
        TenantDbContext CreateDbContext();
    }
}
