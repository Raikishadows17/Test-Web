using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entities
{
    public class RoadRouteRepository : CreateRepository<RoadRoutesDTO,RoadRoutes>, IRoadRouteRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public RoadRouteRepository(IDbContextFactory dbContextFactory, IMapper mapper):base(dbContextFactory,mapper)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async override Task UpdateAsync(RoadRoutesDTO entity)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var rowAffected = await dbContext.RoadRoutes.Where(r => r.Active && r.Id == entity.RoadRoutesId)
                .ExecuteUpdateAsync(r => r
                    .SetProperty(r => r.TerminalOrigenId, entity.TerminalOrigenId)
                    .SetProperty(r => r.TerminalDestinoId, entity.TerminalDestinoId)
                    .SetProperty(r => r.RouteName, entity.RouteName)
                    .SetProperty(r => r.Comments, entity.Comments)
                    .SetProperty(r => r.RouteDate, entity.RouteDate)
                    .SetProperty(r => r.TotalKms, entity.TotalKms)
                    .SetProperty(r => r.EstimatedTime, entity.EstimatedTime));

            if (rowAffected == 0)
                throw new NotFoundException("No se aplicó la actualización, talvez no hay ruta asignada al id proporcionado, contacta al administrador");

            await dbContext.SaveChangesAsync();
        }
    }
}
