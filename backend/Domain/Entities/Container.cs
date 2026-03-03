using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Container")]
    public class Container : IActivable,IEntity
    {
        [Key]
        [Column("Container_Id")]
        public int Id { get; set; }

        [Column("ContainerType_Id")]
        public int ContainerTypeId { get; set; }

        [Column("Container_Red_Id")]
        public int? ContainerRedId { get; set; }

        [Column("Shipping_Line_Id")]
        public int ShippingLineId { get; set; }

        [MaxLength(50)]
        [Column("Size")]
        public string? Size { get; set; }

        [Column("Weight_Kg", TypeName = "decimal(18,2)")]
        public decimal? WeightKg { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Container_Number")]
        public string ContainerNumber { get; set; } = string.Empty;

        [Column("Red_Entry_date")]
        public DateTime? RedEntryDate { get; set; }

        [Column("Red_Liberation_date")]
        public DateTime? RedLiberationDate { get; set; }

        [MaxLength(100)]
        [Column("Container_Type")]
        public string? ContainerTypeName { get; set; }

        [MaxLength(200)]
        [Column("Cntr_Document_Recuest")]
        public string? CntrDocumentRecuest { get; set; }

        [MaxLength(200)]
        [Column("Archieve_Request")]
        public string? ArchieveRequest { get; set; }

        [MaxLength(13)]
        [Column("Cntr_Document_Rfc")]
        public string? CntrDocumentRfc { get; set; }

        [MaxLength(13)]
        [Column("Rfc_Company")]
        public string? RfcCompany { get; set; }

        [MaxLength(300)]
        [Column("Company_Name")]
        public string? CompanyName { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        // Navigation Properties
        [ForeignKey(nameof(ContainerTypeId))]
        public virtual ContainerType ContainerType { get; set; } = null!;

        [ForeignKey(nameof(ContainerRedId))]
        public virtual Container? ContainerRed { get; set; }

        [ForeignKey(nameof(ShippingLineId))]
        public virtual ShippingLine? ShippingLine { get; set; }

        public virtual ICollection<ContainerSeals> ContainerSeals { get; set; } = new List<ContainerSeals>();
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
        public virtual ICollection<FullEmpty> FullEmpties { get; set; } = new List<FullEmpty>();
        public virtual ICollection<SchedulededAppointment> SchedulededAppointments { get; set; } = new List<SchedulededAppointment>();        
    }
}
