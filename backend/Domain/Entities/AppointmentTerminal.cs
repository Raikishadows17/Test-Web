using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Appointment_Terminal")]
    public class AppointmentTerminal : IActivable,IEntity
    {
        [Key]
        [Column("Appo_Terminal_Id")]
        public int Id { get; set; }

        [Column("Terminal_Id")]
        public int TerminalId { get; set; }

        [MaxLength(200)]
        [Column("Appo_Category")]
        public string? AppoCategory { get; set; }

        [MaxLength(200)]
        [Column("Appo_Name")]
        public string? AppoName { get; set; }

        [MaxLength(200)]
        [Column("Appo_Block")]
        public string? AppoBlock { get; set; }

        [Column("Appo_Date_Ini")]
        public DateTime? AppoDateIni { get; set; }

        [Column("Appo_Date_Fin")]
        public DateTime? AppoDateFin { get; set; }

        [Column("Appo_Date_IniEta")]
        public DateTime? AppoDateIniEta { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(TerminalId))]
        public virtual Terminal Terminal { get; set; } = null!;

        public virtual ICollection<SchedulededAppointment> SchedulededAppointments { get; set; } = new List<SchedulededAppointment>();
    }
}
