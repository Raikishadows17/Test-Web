using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.DTOs
{
    public class ServiceDTO
    {

        public int ServiceId { get; set; }
        
        public int EquipamentId { get; set; }
        
        public int ContainerId { get; set; }
        
        public int TripTypeId { get; set; }

        public int CustomerId { get; set; }

        public int StatusServiceId { get; set; }
        
        public DateTime? CreationDate { get; set; }

        public string? UserCreation { get; set; }

        public DateTime? AutorizationCCODate { get; set; }

        public DateTime? AutorizationCFODate { get; set; }

        public string? OperatedTraffic { get; set; }

        public string? ServiceSingleFull { get; set; }
        
    }
}
