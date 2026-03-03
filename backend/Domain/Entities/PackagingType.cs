using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Packaging_Type")]
    public class PackagingType : IActivable
    {
        [Key]
        [Column("Packaging_Type_Id")]
        public int PackagingTypeId { get; set; }

        [MaxLength(200)]
        [Column("Packaging_Clasiffication")]
        public string PackagingClasiffication { get; set; }

        [MaxLength(200)]
        [Column("Packaging_Name")]
        public string PackagingName { get; set; }

        [MaxLength(500)]
        [Column("Packaging_Description")]
        public string? PackagingDescription { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        public virtual ICollection<LooseCommodity> LooseCommodities { get; set; } = new List<LooseCommodity>();
    }
}
