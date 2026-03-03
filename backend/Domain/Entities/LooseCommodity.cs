using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Loose_Commodity")]
    public class LooseCommodity : IActivable
    {
        [Key]
        [Column("Loose_Commodity_Id")]
        public int LooseCommodityId { get; set; }

        [Column("Packaging_Type_Id")]
        public int PackagingTypeId { get; set; }

        [Column("Service_Id")]
        public int ServiceId { get; set; }

        [MaxLength(200)]
        [Column("Commodity")]
        public string? Commodity { get; set; }

        [Column("Quantity")]
        public int? Quantity { get; set; }

        [Column("Unload_Date")]
        public DateTime? UnloadDate { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(PackagingTypeId))]
        public virtual PackagingType PackagingType { get; set; } = null!;

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; } = null!;
    }
}
