using Application.Interface.Repository.Common;
using Application.Interface.Service.Common;
using Domain.Exceptions;

namespace Application.Services.Common
{
    public abstract class BaseService<T> : IService<T> where T : class
    {

        protected readonly IRepository<T> _repository;        

        protected BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if(result == null)
                throw new NotFoundException($"No se encotró la entidad con el id: {id}.");

            return result;

        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
