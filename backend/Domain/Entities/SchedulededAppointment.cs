using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Scheduleded_Appointment")]
    public class SchedulededAppointment : IActivable
    {
        [Key]
        [Column("Sche_Appointment_Id")]
        public int ScheAppointmentId { get; set; }

        [Column("Appo_Terminal_Id")]
        public int AppoTerminalId { get; set; }

        [Column("Services_DateEvents")]
        public int ServicesDateEventsId { get; set; }

        [Column("Full_Empty_Id")]
        public int FullEmptyId { get; set; }

        [Column("Container_Id")]
        public int ContainerId { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(AppoTerminalId))]
        public virtual AppointmentTerminal AppointmentTerminal { get; set; } = null!;

        [ForeignKey(nameof(ServicesDateEventsId))]
        public virtual ServicesDateEvents ServicesDateEvent { get; set; } = null!;

        [ForeignKey(nameof(FullEmptyId))]
        public virtual FullEmpty? FullEmpty { get; set; }

        [ForeignKey(nameof(ContainerId))]
        public virtual Container? Container { get; set; }
    }
}
