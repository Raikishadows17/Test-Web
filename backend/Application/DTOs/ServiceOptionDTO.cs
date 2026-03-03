using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ServiceOptionDTO
    {
        public ICollection<IMODto> IMO { get; set; }
        public ICollection<TripTypeDTO> TripType { get; set; }
        public ICollection<EquipmentDTO> Equipment { get; set; }
        public ICollection<TerminalDTO> Terminal { get; set; } //Se puede usar para origen y destino
        public ICollection<ContainerDTO> Container { get; set; }
        public ICollection<ContainerTypeDTO> ContainerType { get; set; }
        public ICollection<RoadRoutesDTO> RoadRoutes { get; set; }
        public ICollection<CustomerDTO> Customer { get; set; }
        public ICollection<EmployeeDTO> Operator { get; set; }
    }
}
