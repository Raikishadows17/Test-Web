using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Employee_Disabled")]
    public class EmployeeDisabled
    {
        [Key]
        [Column("Emp_Disabled_Id")]
        public int EmpDisabledId { get; set; }

        [Column("Emp_Id")]
        public int EmpId { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column("End_Date")]
        public DateTime? EndDate { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(EmpId))]
        public virtual Employee Employee { get; set; } = null!;
    }
}
