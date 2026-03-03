using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Services_DateEvents")]
    public class ServicesDateEvents : IActivable
    {
        [Key]
        [Column("Services_DateEvents")]
        public int ServicesDateEventsId { get; set; }

        [Column("Service_Id")]
        public int ServiceId { get; set; }

        [Column("DateEvents_Type_Id")]
        public int DateEventsTypeId { get; set; }

        [Column("Event_Classification_Id")]
        public int EventClassificationId { get; set; }

        [Column("Event_Date")]
        public DateTime EventDate { get; set; }

        [Column("Event_Expiration")]
        public DateTime? EventExpiration { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; } = null!;

        [ForeignKey(nameof(DateEventsTypeId))]
        public virtual DateEventsType DateEventsType { get; set; } = null!;

        [ForeignKey(nameof(EventClassificationId))]
        public virtual EventClassification? EventClassification { get; set; }

        public virtual ICollection<SchedulededAppointment> SchedulededAppointments { get; set; } = new List<SchedulededAppointment>();
    }
}
