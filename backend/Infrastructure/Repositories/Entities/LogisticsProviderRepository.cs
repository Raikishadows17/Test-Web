using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entities
{
    public class LogisticsProviderRepository : CreateRepository<LogicProviderDTO, LogisticsProvider>, ILogisticsProviderRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public LogisticsProviderRepository(IDbContextFactory dbContextFactory, IMapper mapper):base (dbContextFactory, mapper)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async override Task UpdateAsync(LogicProviderDTO entity)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var rowAffected = await dbContext.LogisticsProviders.Where(lp => lp.Id == entity.LogisticsProviderId && lp.Active)
                                        .ExecuteUpdateAsync(lp => lp
                                            .SetProperty(lp => lp.Name, entity.Name)
                                            .SetProperty(lp => lp.FullName, entity.FullName)
                                            .SetProperty(lp => lp.UrlImage, entity.UrlImage)
                                            .SetProperty(lp => lp.Comments, entity.Comments));

            if(rowAffected == 0)
                throw new NotFoundException("No se aplicó la actualización, talvez no hay proveedor asignado al id proporcionado, contacta al administrador");

            await dbContext.SaveChangesAsync();
        }
    }
}
