using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public bool Foreign { get; set; }
        public bool Full { get; set; }
        public string Numero_Economico { get; set; } = string.Empty;
        public string Invoice_Document_Path { get; set; } = string.Empty;
        public string Physycal_check_Document_Path { get; set; } = string.Empty;
        public DateTime Physycal_check_Validation_Date { get; set; }
        public string Plates { get; set; } = string.Empty;
        public int Plates_validation_Year { get; set; }
        public int Diesel_Capacity { get; set; }
    }
}
