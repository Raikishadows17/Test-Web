using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;

namespace Application.Services
{
    public class ContainerService : BaseService<ContainerDTO>,IContainerService
    {
        private readonly IContainerRepository _containerRepository;


        public ContainerService(IContainerRepository containerRepository) : base(containerRepository) 
        {
        
        }

    }
}
