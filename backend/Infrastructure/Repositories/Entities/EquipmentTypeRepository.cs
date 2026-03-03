using Application.DTOs;
using Application.Interface.Repository.Common;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories.Entities
{
    public class EquipmentTypeRepository : GetDataRepository<EquipmentTypeDTO, EquipmentType>, IEquipmentTypeRepository
    {
        public EquipmentTypeRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }

    }
}
