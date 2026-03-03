using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Services")]
    public class Service : IActivable,IEntity
    {
        [Key]
        [Column("Service_Id")]
        public int Id { get; set; }

        [Column("Equipament_Id")]
        public int EquipamentId { get; set; }

        [Column("Container_Id")]
        public int ContainerId { get; set; }

        [Column("Trip_Type_Id")]
        public int TripTypeId { get; set; }

        [Column("Customer_id")]
        public int CustomerId { get; set; }

        [Column("StatusServiceId")]
        public int StatusServiceId { get; set; }

        [Column("Creation_Date")]
        public DateTime? CreationDate { get; set; }

        [MaxLength(200)]
        [Column("User_Creation")]
        public string? UserCreation { get; set; }

        [Column("Autorization_CCO_Date")]
        public DateTime? AutorizationCCODate { get; set; }

        [Column("Autorization_CFO_Date")]
        public DateTime? AutorizationCFODate { get; set; }

        [MaxLength(200)]
        [Column("Operated_Traffic")]
        public string? OperatedTraffic { get; set; }

        [MaxLength(200)]
        [Column("Service_SingleFull")]
        public string? ServiceSingleFull { get; set; }

        public bool Active { get; set; } = true;

        // Navigation Properties
        [ForeignKey(nameof(EquipamentId))]
        public virtual Equipment? Equipment { get; set; }

        [ForeignKey(nameof(ContainerId))]
        public virtual Container? Container { get; set; }

        [ForeignKey(nameof(TripTypeId))]
        public virtual TripType? TripType { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(StatusServiceId))]
        public virtual StatusService StatusService { get; set; }

        public virtual ICollection<Service_ServiceEvent> ServiceEvents { get; set; } = new List<Service_ServiceEvent>();
        public virtual ICollection<RoutesServices> RoutesServices { get; set; } = new List<RoutesServices>();
        public virtual ICollection<AssignedEquipment> AssignedEquipments { get; set; } = new List<AssignedEquipment>();
        public virtual ICollection<AssignedOperator> AssignedOperators { get; set; } = new List<AssignedOperator>();
        public virtual ICollection<FullEmpty> FullEmpties { get; set; } = new List<FullEmpty>();
        public virtual ICollection<LooseCommodity> LooseCommodities { get; set; } = new List<LooseCommodity>();        
        public virtual ICollection<ServicesComment> ServicesComments { get; set; } = new List<ServicesComment>();
        public virtual ICollection<ServicesDateEvents> ServicesDateEvents { get; set; } = new List<ServicesDateEvents>();
        public virtual ICollection<TerminalTicket> TerminalTickets { get; set; } = new List<TerminalTicket>();        
    }
}
