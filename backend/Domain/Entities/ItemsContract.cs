using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Items_Contract")]
    public class ItemsContract
    {
        [Key]
        [Column("Items_Contract_Id")]
        public int ItemsContractId { get; set; }

        [Column("Contract_Id")]
        public int ContractId { get; set; }

        [Column("Items_Catalog_Id")]
        public int ItemsCatalogId { get; set; }
        
        [Column("Client_Condition_Id")]
        public int ClientConditionId { get; set; }

        [Column("Status_Id")]
        public int StatusId { get; set; }

        [Column("Amount", TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }

        [Column("Quantity")]
        public int? Quantity { get; set; }

        [Column("Amount_Percent", TypeName = "decimal(18,4)")]
        public decimal? AmountPercent { get; set; }

        [ForeignKey(nameof(ContractId))]
        public virtual Contract Contract { get; set; } = null!;

        [ForeignKey(nameof(ItemsCatalogId))]
        public virtual ItemsCatalog ItemsCatalog { get; set; } = null!;

        [ForeignKey(nameof(ClientConditionId))]
        public virtual ClientCondition? ClientCondition { get; set; }

        [ForeignKey(nameof(StatusId))]
        public virtual Status? Status { get; set; }
    }
}
