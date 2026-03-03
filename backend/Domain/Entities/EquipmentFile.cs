using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Equipment_File")]
    public class EquipmentFile : IActivable
    {
        [Key]
        [Column("Eqpm_File_Id")]
        public int EqpmFileId { get; set; }

        [Column("Eqpm_Doc_Id")]
        public int EqpmDocId { get; set; }

        [Column("Equipment_id")]
        public int EquipmentId { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string? Name { get; set; }

        [MaxLength(500)]
        [Column("Description")]
        public string? Description { get; set; }

        [MaxLength(100)]
        [Column("State")]
        public string? State { get; set; }

        [MaxLength(500)]
        [Column("Url_Document_Path")]
        public string? UrlDocumentPath { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [Column("Date_Apply")]
        public DateTime? DateApply { get; set; }

        [Column("Date_Installation")]
        public DateTime? DateInstallation { get; set; }

        [Column("Date_Exp")]
        public DateTime? DateExp { get; set; }

        [MaxLength(500)]
        [Column("Url_Image")]
        public string? UrlImage { get; set; }

        [ForeignKey(nameof(EqpmDocId))]
        public virtual EquipmentDocument EquipmentDocument { get; set; } = null!;

        [ForeignKey(nameof(EquipmentId))]
        public virtual Equipment Equipment { get; set; } = null!;
    }
}
