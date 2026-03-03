using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Credit")]
    public class Credit
    {
        [Key]
        [Column("Credit_Id")]
        public int CreditId { get; set; }

        [Column("Credit_Type_Id")]
        public int CreditTypeId { get; set; }

        [Column("CreditStatus_id")]
        public int CreditStatusId { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column("End_Date")]
        public DateTime? EndDate { get; set; }

        [MaxLength(200)]
        [Column("Status")]
        public string? Status { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(CreditTypeId))]
        public virtual CreditType CreditType { get; set; } = null!;

        [ForeignKey(nameof(CreditStatusId))]
        public virtual CreditStatus CreditStatus { get; set; } = null!;

        public virtual ICollection<CreditCustomer> CreditCustomers { get; set; } = new List<CreditCustomer>();
    }
}
