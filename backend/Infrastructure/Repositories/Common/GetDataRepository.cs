using Application.Interface.Repository.Common;
using Domain.Common;
using Infrastructure.Factories;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Common
{
    public abstract class GetDataRepository<TDto, TEntity> : IGetDataRepository<TDto> where TDto : class
                                                                                      where TEntity : class, 
                                                                                      IActivable,IEntity
    {
        private readonly IDbContextFactory _dbContextFactory;

        protected GetDataRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Set<TEntity>().Where(e => e.Active)
                                    .AsNoTracking()
                                    .ProjectToType<TDto>()
                                    .ToListAsync();

        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Set<TEntity>().Where(e => e.Active && e.Id == id)
                        .AsNoTracking()
                        .ProjectToType<TDto>()
                        .FirstOrDefaultAsync();

        }
    }
}
