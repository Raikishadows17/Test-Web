using Application.Interface.Repository;
using Application.Interface.Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IRepository<Equipment> _equipmentRepository;

        public EquipmentService(IRepository<Equipment> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<IEnumerable<Equipment>> GetAllEquipmentAsync()
        {
            return _equipmentRepository.GetAllAsync();
        }
    }
}
