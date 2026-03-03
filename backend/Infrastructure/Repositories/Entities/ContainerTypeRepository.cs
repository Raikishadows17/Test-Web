using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories.Entities
{
    public class ContainerTypeRepository : GetDataRepository<ContainerTypeDTO, ContainerType>, IContainerTypeRepository
    {
        public ContainerTypeRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
