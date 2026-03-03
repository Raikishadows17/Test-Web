using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Client_Condition")]
    public class ClientCondition : IActivable
    {
        [Key]
        [Column("Client_Condition_Id")]
        public int ClientConditionId { get; set; }

        [MaxLength(200)]
        [Column("Item_Catalog")]
        public string? ItemCatalog { get; set; }

        [MaxLength(200)]
        [Column("Item_Name")]
        public string? ItemName { get; set; }

        [MaxLength(100)]
        [Column("Item_Code")]
        public string? ItemCode { get; set; }

        [MaxLength(500)]
        [Column("Item_Description")]
        public string? ItemDescription { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        public virtual ICollection<ItemsContract> ItemsContracts { get; set; } = new List<ItemsContract>();
    }
}
