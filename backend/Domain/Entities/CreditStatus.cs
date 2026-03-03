using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Credit_Status")]
    public class CreditStatus
    {
        [Key]
        [Column("CreditStatus_id")]
        public int CreditStatusId { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Desc")]
        public string? Desc { get; set; }

        // Navigation Properties
        public virtual ICollection<Credit> Credits { get; set; } = new List<Credit>();
    }
}
