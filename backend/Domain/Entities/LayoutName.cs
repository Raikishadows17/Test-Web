using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Layout_Name")]
    public class LayoutName
    {
        [Key]
        [Column("Layout_Name_Id")]
        public int LayoutNameId { get; set; }

        [Column("Terminal_Id")]
        public int TerminalId { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Full_Name")]
        public string FullName { get; set; }

        [MaxLength(500)]
        [Column("Url_Image")]
        public string? UrlImage { get; set; }

        [ForeignKey(nameof(TerminalId))]
        public virtual Terminal? Terminal { get; set; }
    }
}
