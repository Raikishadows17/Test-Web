using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Credit_Type")]
    public class CreditType
    {
        [Key]
        [Column("Credit_Type_Id")]
        public int CreditTypeId { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [Column("Activve")]
        public bool Activve { get; set; }

        // Navigation Properties
        public virtual ICollection<Credit> Credits { get; set; } = new List<Credit>();
    }
}
