using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Forbidden_Employee")]
    public class ForbiddenEmployee
    {
        [Key]
        [Column("Forb_Employee_Id")]
        public int ForbEmployeeId { get; set; }

        [Column("Emp_Id")]
        public int EmpId { get; set; }

        [Column("Terminal_Id")]
        public int TerminalId { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column("End_Date")]
        public DateTime? EndDate { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(EmpId))]
        public virtual Employee Employee { get; set; } = null!;

        [ForeignKey(nameof(TerminalId))]
        public virtual Terminal Terminal { get; set; } = null!;
    }
}
