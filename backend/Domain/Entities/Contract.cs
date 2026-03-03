using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Contract")]
    public class Contract
    {
        [Key]
        [Column("Contract_Id")]
        public int ContractId { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        [Column("Status_Customer_Id")]
        public int StatusCustomerId { get; set; }

        [Column("Status_Contract_Id")]
        public int StatusContractId { get; set; }

        [Column("Creation_Date")]
        public DateTime? CreationDate { get; set; }

        [MaxLength(200)]
        [Column("Contract_Name")]
        public string? ContractName { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column("End_Date")]
        public DateTime? EndDate { get; set; }

        [MaxLength(50)]
        [Column("Currency")]
        public string? Currency { get; set; }

        [MaxLength(100)]
        [Column("Contract_Type")]
        public string? ContractType { get; set; }

        [Column("Cancellation_Date")]
        public DateTime? CancellationDate { get; set; }

        [Column("Credit_Days")]
        public int? CreditDays { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(StatusCustomerId))]
        public virtual Status? StatusCustomer { get; set; }

        [ForeignKey(nameof(StatusContractId))]
        public virtual Status? StatusContract { get; set; }

        public virtual ICollection<ItemsContract> ItemsContracts { get; set; } = new List<ItemsContract>();
    }
}
