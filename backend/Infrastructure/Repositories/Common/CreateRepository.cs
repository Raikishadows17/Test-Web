using Application.Interface.Repository.Common;
using Domain.Common;
using Domain.Exceptions;
using Infrastructure.Factories;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Common
{
    public abstract class CreateRepository<TDto, TEntity> :GetDataRepository<TDto,TEntity>, ICreateRepository<TDto>,IEditableRepository<TDto> where TDto : class
                                                                            where TEntity : class, IActivable, IEntity
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IMapper _mapper;

        protected CreateRepository(IDbContextFactory dbContextFactory,IMapper mapper):base(dbContextFactory) {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task AddAsync(TDto entityDto)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var entity = _mapper.Map<TEntity>(entityDto);

            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var rowAffected = await dbContext.Set<TEntity>().Where(e => e.Id == id && e.Active)
                                                    .ExecuteUpdateAsync( e => e.SetProperty( e=> e.Active,false ));

            if (rowAffected == 0)
                throw new NotFoundException("No se pudo eliminar la entidad, talvez no exista una entidad con el id proporcionado");

            await dbContext.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(TDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
