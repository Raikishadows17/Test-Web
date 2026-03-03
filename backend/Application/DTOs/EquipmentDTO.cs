using Domain.Entities;

namespace Application.DTOs
{
    public class EquipmentDTO
    {        
        public int EquipmentId { get; set; }
        public int? EquipTypeId { get; set; }
        public int? TerminalId { get; set; }
        public int? TripTypeId { get; set; }
        public string? EconomicNumber { get; set; }
        public string? Plates { get; set; }
        public string? PlatesEstate { get; set; }
        public decimal? DieselCapacity { get; set; }
        public decimal? TowingCapacity { get; set; }
        public bool? AvailableRepair { get; set; }
        public bool? AvailableRed { get; set; }
        public bool? AvailableRoute { get; set; }
        public bool? AvailableMantainance { get; set; }
        public bool? AvailablePartners { get; set; }
        public bool? LabeledUnit { get; set; }

        public virtual Terminal? Terminal { get; set; }
        public virtual TripType? TripType { get; set; }
        public virtual EquipmentType? EquipmentType { get; set; }
        public virtual EquipmentStatus? EquipmentStatus { get; set; }
    }
}
