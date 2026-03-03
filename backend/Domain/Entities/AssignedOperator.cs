using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Assigned_Operator")]
    public class AssignedOperator : IActivable
    {
        [Key]
        [Column("Assigned_Operator_Id")]
        public int AssignedOperatorId { get; set; }

        [Column("Emp_Id")]
        public int EmpId { get; set; }

        [Column("Service_Id")]
        public int ServiceId { get; set; }

        [Column("Assign_Date")]
        public DateTime? AssignDate { get; set; }

        [Column("Unassign_Date")]
        public DateTime? UnassignDate { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [Column("Pernocta_Date")]
        public DateTime? PernoctaDate { get; set; }

        [ForeignKey(nameof(EmpId))]
        public virtual Employee Employee { get; set; } = null!;

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; } = null!;

        public virtual ICollection<OperatorEquipment> OperatorEquipments { get; set; } = new List<OperatorEquipment>();
    }
}
