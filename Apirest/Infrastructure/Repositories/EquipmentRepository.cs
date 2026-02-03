using Application.Interface.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EquipmentRepository : IRepository<Equipment>
    {
        private List<Equipment> _equipments = new List<Equipment>()
        {
            new Equipment { EquipmentId = 1, Foreign = false, Full = true,  Numero_Economico = "EQ-1001", Invoice_Document_Path = "docs/invoices/eq-1001.pdf", Physycal_check_Document_Path = "docs/checks/eq-1001.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-6), Plates = "ABC-101", Plates_validation_Year = 2026, Diesel_Capacity = 400 },
            new Equipment { EquipmentId = 2, Foreign = true,  Full = false, Numero_Economico = "EQ-1002", Invoice_Document_Path = "docs/invoices/eq-1002.pdf", Physycal_check_Document_Path = "docs/checks/eq-1002.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-12), Plates = "DEF-202", Plates_validation_Year = 2025, Diesel_Capacity = 350 },
            new Equipment { EquipmentId = 3, Foreign = false, Full = true,  Numero_Economico = "EQ-1003", Invoice_Document_Path = "docs/invoices/eq-1003.pdf", Physycal_check_Document_Path = "docs/checks/eq-1003.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-3), Plates = "GHI-303", Plates_validation_Year = 2027, Diesel_Capacity = 420 },
            new Equipment { EquipmentId = 4, Foreign = false, Full = false, Numero_Economico = "EQ-1004", Invoice_Document_Path = "docs/invoices/eq-1004.pdf", Physycal_check_Document_Path = "docs/checks/eq-1004.pdf", Physycal_check_Validation_Date = DateTime.Today.AddYears(-1), Plates = "JKL-404", Plates_validation_Year = 2024, Diesel_Capacity = 380 },
            new Equipment { EquipmentId = 5, Foreign = true,  Full = true,  Numero_Economico = "EQ-1005", Invoice_Document_Path = "docs/invoices/eq-1005.pdf", Physycal_check_Document_Path = "docs/checks/eq-1005.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-2), Plates = "MNO-505", Plates_validation_Year = 2026, Diesel_Capacity = 500 },
            new Equipment { EquipmentId = 6, Foreign = false, Full = false, Numero_Economico = "EQ-1006", Invoice_Document_Path = "docs/invoices/eq-1006.pdf", Physycal_check_Document_Path = "docs/checks/eq-1006.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-8), Plates = "PQR-606", Plates_validation_Year = 2025, Diesel_Capacity = 360 },
            new Equipment { EquipmentId = 7, Foreign = false, Full = true,  Numero_Economico = "EQ-1007", Invoice_Document_Path = "docs/invoices/eq-1007.pdf", Physycal_check_Document_Path = "docs/checks/eq-1007.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-4), Plates = "STU-707", Plates_validation_Year = 2028, Diesel_Capacity = 410 },
            new Equipment { EquipmentId = 8, Foreign = true,  Full = false, Numero_Economico = "EQ-1008", Invoice_Document_Path = "docs/invoices/eq-1008.pdf", Physycal_check_Document_Path = "docs/checks/eq-1008.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-18), Plates = "VWX-808", Plates_validation_Year = 2023, Diesel_Capacity = 330 },
            new Equipment { EquipmentId = 9, Foreign = false, Full = true,  Numero_Economico = "EQ-1009", Invoice_Document_Path = "docs/invoices/eq-1009.pdf", Physycal_check_Document_Path = "docs/checks/eq-1009.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-1), Plates = "YZA-909", Plates_validation_Year = 2026, Diesel_Capacity = 450 },
            new Equipment { EquipmentId = 10, Foreign = false, Full = false, Numero_Economico = "EQ-1010", Invoice_Document_Path = "docs/invoices/eq-1010.pdf", Physycal_check_Document_Path = "docs/checks/eq-1010.pdf", Physycal_check_Validation_Date = DateTime.Today.AddMonths(-9), Plates = "BCD-010", Plates_validation_Year = 2025, Diesel_Capacity = 390 }
        };

        public Task AddAsync(Equipment entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Equipment>> GetAllAsync()
        {
          return Task.FromResult<IEnumerable<Equipment>>(_equipments);
        }

        public Task<Equipment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
