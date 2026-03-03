using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Terminal_Ticket")]
    public class TerminalTicket
    {
        [Key]
        [Column("Terminal_Ticket_Id")]
        public int TerminalTicketId { get; set; }

        [Column("Service_Id")]
        public int ServiceId { get; set; }

        [Column("Container1_Id")]
        public int Container1Id { get; set; }

        [Column("Container2_Id")]
        public int Container2Id { get; set; }

        [Column("Terminal_Id")]
        public int TerminalId { get; set; }

        [Column("Operator_Equipment_Id")]
        public int OperatorEquipmentId { get; set; }

        [MaxLength(500)]
        [Column("Url_Ticket")]
        public string? UrlTicket { get; set; }

        [MaxLength(500)]
        [Column("Archieve_Ticket")]
        public string? ArchieveTicket { get; set; }

        [Column("Terminal_TicketDate")]
        public DateTime? TerminalTicketDate { get; set; }

        [Column("Terminal_TicketExpDate")]
        public DateTime? TerminalTicketExpDate { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; } = null!;

        [ForeignKey(nameof(Container1Id))]
        public virtual Container? Container1 { get; set; }

        [ForeignKey(nameof(Container2Id))]
        public virtual Container? Container2 { get; set; }

        [ForeignKey(nameof(TerminalId))]
        public virtual Terminal? Terminal { get; set; }

        [ForeignKey(nameof(OperatorEquipmentId))]
        public virtual OperatorEquipment? OperatorEquipment { get; set; }
    }
}
