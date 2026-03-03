using Application.DTOs;
using Application.Interface.Repository.Common;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;

namespace Application.Services
{
    public class EquipmentTypeService : GetDataService<EquipmentTypeDTO>, IEquipmentTypeService
    {
        public EquipmentTypeService(IEquipmentTypeRepository equipmentTypeRepository) : base (equipmentTypeRepository)
        {

        }
    }
}
