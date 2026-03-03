using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Credit_Customer")]
    public class CreditCustomer
    {
        [Key]
        [Column("CreditCusto_id")]
        public int CreditCustoId { get; set; }

        [Column("Customer_id")]
        public int CustomerId { get; set; }

        [Column("Credit_id")]
        public int CreditId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(CreditId))]
        public virtual Credit Credit { get; set; } = null!;
    }
}
