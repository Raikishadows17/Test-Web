using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Equipment_Document")]
    public class EquipmentDocument : IActivable
    {
        [Key]
        [Column("Eqpm_Doc_Id")]
        public int EqpmDocId { get; set; }

        [MaxLength(100)]
        [Column("Type")]
        public string? Type { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string? Name { get; set; }

        [MaxLength(500)]
        [Column("Description")]
        public string? Description { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        public virtual ICollection<EquipmentFile> EquipmentFiles { get; set; } = new List<EquipmentFile>();
    }
}
