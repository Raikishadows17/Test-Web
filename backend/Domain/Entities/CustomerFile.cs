using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Customer_File")]
    public class CustomerFile : IActivable
    {
        [Key]
        [Column("Eqpm_File_Id")]
        public int EqpmFileId { get; set; }

        [Column("Cust_Doc_Id")]
        public int CustDocId { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string? Name { get; set; }

        [MaxLength(500)]
        [Column("Description")]
        public string? Description { get; set; }

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

        [Column("Date_Exp")]
        public DateTime? DateExp { get; set; }

        [MaxLength(500)]
        [Column("Url_Image")]
        public string? UrlImage { get; set; }

        [ForeignKey(nameof(CustDocId))]
        public virtual CustomerDocument CustomerDocument { get; set; } = null!;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;
    }
}
