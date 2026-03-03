using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;

namespace Application.Services
{
    public class ServiceService : BaseService<ServiceDTO> ,IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        
        public ServiceService(IServiceRepository repository) : base(repository) { 
            _serviceRepository = repository;
        }

        public async Task<ServiceOptionDTO> GetServiceCreationOptionAsync()
        {
            return await _serviceRepository.GetServiceCreationOptionAsync();
        }
    }
}
