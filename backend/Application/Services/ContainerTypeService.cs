using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;

namespace Application.Services
{
    public class ContainerTypeService : GetDataService<ContainerTypeDTO>, IContainerTypeService
    {
        public ContainerTypeService(IContainerTypeRepository containerTypeRepository) : base(containerTypeRepository)
        {

        }
    }
}
