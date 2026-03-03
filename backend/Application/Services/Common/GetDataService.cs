using Application.Interface.Repository.Common;
using Application.Interface.Service.Common;
using Domain.Exceptions;

namespace Application.Services.Common
{
    public abstract class GetDataService<T> : IGetDataService<T> where T : class
    {
        private readonly IGetDataRepository<T> _getDataRepository;

        public GetDataService(IGetDataRepository<T> getDataRepository)
        {
            _getDataRepository = getDataRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _getDataRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _getDataRepository.GetByIdAsync(id);
            
            if(result == null)
                throw new NotFoundException($"No se encotró la entidad con el id: {id}.");

            return result;
        }
    }
}
