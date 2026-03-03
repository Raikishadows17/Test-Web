using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Status")]
    public class Status : IActivable
    {
        [Key]
        [Column("Status_Id")]
        public int StatusId { get; set; }

        [MaxLength(200)]
        [Column("Status_Classification")]
        public string StatusClassification { get; set; }

        [MaxLength(200)]
        [Column("Status_Name")]
        public string StatusName { get; set; }

        [MaxLength(500)]
        [Column("Status_Description")]
        public string? StatusDescription { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [Column("Sequence")]
        public int? Sequence { get; set; }
    }
}
