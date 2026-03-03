using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Employee_Category")]
    public class EmployeeCategory
    {
        [Key]
        [Column("Emp_Cat_Id")]
        public int EmpCatId { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("Category")]
        public string Category { get; set; }

        [MaxLength(500)]
        [Column("Cat_Description")]
        public string? CatDescription { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

    }
}
