using Application.Interface.Context;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Factories
{
    public class TenantDbContextFactory : IDbContextFactory
    {
        private readonly ITenantContext _tenantContext;

        public TenantDbContextFactory(ITenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        public TenantDbContext CreateDbContext()
        {
            var tenant = _tenantContext.GetTenant();

            if(tenant == null || !tenant.Active)
                throw new InvalidOperationException("No se pudo obtener el tenant del contexto o esta inactivo");
            
            if(string.IsNullOrWhiteSpace(tenant.DatabaseConnectionString) )
                throw new InvalidOperationException("El connection string para el tenant '{tenant.TenantName}' no está configurado.");

            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();

            optionsBuilder.UseSqlServer(tenant.DatabaseConnectionString,sqlOptions => { 
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
                sqlOptions.CommandTimeout(60);
            })
              //.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
              //.EnableSensitiveDataLogging()
              ;

            return new TenantDbContext(optionsBuilder.Options);

        }
    }
}
