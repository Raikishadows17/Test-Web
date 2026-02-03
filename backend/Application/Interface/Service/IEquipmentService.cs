using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Service
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetAllEquipmentAsync();
    }
}
