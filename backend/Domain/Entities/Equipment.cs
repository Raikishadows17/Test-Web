using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Equipment")]
    public class Equipment : IActivable,IEntity
    {
        [Key]
        [Column("Equipment_id")]
        public int Id { get; set; }

        [Column("EquipType_id")]
        public int EquipTypeId { get; set; }

        [Column("terminal_id")]
        public int TerminalId { get; set; }

        [Column("Trip_Type_Id")]
        public int TripTypeId { get; set; }
        
        [Column("Equipment_Status")]
        public int EquipmentStatusId { get; set; }

        [MaxLength(100)]
        [Column("Economic_Number")]
        public string? EconomicNumber { get; set; }

        [MaxLength(100)]
        [Column("Plates")]
        public string? Plates { get; set; }

        [MaxLength(100)]
        [Column("Plates_Estate")]
        public string? PlatesEstate { get; set; }

        [Column("Diesel_capacity", TypeName = "decimal(18,2)")]
        public decimal? DieselCapacity { get; set; }

        [Column("towing_capacity", TypeName = "decimal(18,2)")]
        public decimal? TowingCapacity { get; set; }

        public bool? AvailablePartners { get; set; }
        [Column("Color")]
        public string Color { get; set; } = string.Empty;

        [Column("Active")]
        public bool Active { get; set; } = true;

        [Column("Labeled_Unit")]
        public bool? LabeledUnit { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(EquipTypeId))]
        public virtual EquipmentType? EquipmentType { get; set; }

        [ForeignKey(nameof(TerminalId))]
        public virtual Terminal? Terminal { get; set; }

        [ForeignKey(nameof(TripTypeId))]
        public virtual TripType? TripType { get; set; }
        
        [ForeignKey(nameof(EquipmentStatusId))]
        public virtual EquipmentStatus? EquipmentStatus { get; set; }

        public virtual ICollection<AssignedEquipment> AssignedEquipments { get; set; } = new List<AssignedEquipment>();
        public virtual ICollection<EquipmentFile> EquipmentFiles { get; set; } = new List<EquipmentFile>();
        public virtual ICollection<EquipmentRepairLog> EquipmentRepairLogs { get; set; } = new List<EquipmentRepairLog>();
    }
}
