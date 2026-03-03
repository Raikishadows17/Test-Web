using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Container_Seals")]
    public class ContainerSeals : IActivable
    {
        [Key]
        [Column("Container_Seal_Id")]
        public int ContainerSealId { get; set; }

        [Column("Container_Id")]
        public int ContainerId { get; set; }

        [MaxLength(100)]
        [Column("Seal")]
        public string? Seal { get; set; }

        [Column("Sealed_Date")]
        public DateTime? SealedDate { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(ContainerId))]
        public virtual Container Container { get; set; } = null!;
    }
}
