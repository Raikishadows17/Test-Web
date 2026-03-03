using Application.DTOs;
using Application.Interface.Repository.Common;
using Application.Interface.Service.Common;

namespace Application.Interface.Repository.Entities
{
    public interface IServiceRepository : IRepository<ServiceDTO>
    {
        Task<ServiceOptionDTO> GetServiceCreationOptionAsync();
    }
}
