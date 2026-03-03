using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using Domain.Entities;
using MapsterMapper;

namespace Application.Services
{
    public class EquipmentService :BaseService<EquipmentDTO>, IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository):base(equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

    }
}
