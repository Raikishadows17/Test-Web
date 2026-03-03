using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Operator_Equipment")]
    public class OperatorEquipment : IActivable
    {
        [Key]
        [Column("Operator_Equipment_Id")]
        public int OperatorEquipmentId { get; set; }

        [Column("Assigned_Operator_Id")]
        public int AssignedOperatorId { get; set; }

        [Column("Assigned_Equipment_Id")]
        public int AssignedEquipmentId { get; set; }

        [Column("Assign_Date")]
        public DateTime? AssignDate { get; set; }

        [Column("Unassign_Date")]
        public DateTime? UnassignDate { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(AssignedOperatorId))]
        public virtual AssignedOperator AssignedOperator { get; set; } = null!;

        [ForeignKey(nameof(AssignedEquipmentId))]
        public virtual AssignedEquipment AssignedEquipment { get; set; } = null!;

        public virtual ICollection<TerminalTicket> TerminalTickets { get; set; } = new List<TerminalTicket>();
    }
}
