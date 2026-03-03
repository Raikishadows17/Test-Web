using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Payment_Terms")]
    public class PaymentTerms : IActivable
    {
        [Key]
        [Column("paymentTerm_id")]
        public int PaymentTermId { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Desc")]
        public string? Desc { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
