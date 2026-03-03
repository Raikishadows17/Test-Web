using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Full_Empty")]
    public class FullEmpty : IActivable
    {
        [Key]
        [Column("Full_Empty_Id")]
        public int FullEmptyId { get; set; }

        [Column("Service_Id")]
        public int ServiceId { get; set; }

        [Column("Container_Id")]
        public int ContainerId { get; set; }

        [MaxLength(50)]
        [Column("Full_Empty")]
        public string? FullEmptyStatus { get; set; }

        [Column("Full_Empty_Date")]
        public DateTime? FullEmptyDate { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; } = null!;

        [ForeignKey(nameof(ContainerId))]
        public virtual Container? Container { get; set; }

        public virtual ICollection<SchedulededAppointment> SchedulededAppointments { get; set; } = new List<SchedulededAppointment>();
    }
}
