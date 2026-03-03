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
    public class RolRepository : CreateRepository<RolDTO,Rol>, IRolRepository
    {
        private IDbContextFactory _dbContextFactory;

        public RolRepository(IDbContextFactory dbContextFactory, IMapper mapper) : base(dbContextFactory,mapper)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async override Task UpdateAsync(RolDTO entity)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

           var rowaffected = await dbContext.Roles.Where(r => r.Id == entity.RolId && r.Active)
                .ExecuteUpdateAsync(r => r
                    .SetProperty(r => r.Name, entity.Name)
                    .SetProperty(r => r.Descr, entity.Descr)
                    .SetProperty(r => r.Comments, entity.Comments)
                );

            if (rowaffected == 0)
                throw new NotFoundException("No se aplicó la actualizacion, talvez no hay rol asignado al id proporcionado, contacta al administrador");

            dbContext.Roles.Update(dbContext.Roles.Local.First(r => r.Id == entity.RolId));

        }
    }
}
