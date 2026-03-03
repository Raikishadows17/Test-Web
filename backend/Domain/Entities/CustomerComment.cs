using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Customer_Comment")]
    public class CustomerComment
    {
        [Key]
        [Column("Cust_Com_id")]
        public int CustComId { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        [Column("Comment_Id")]
        public int CommentId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; } = null!;
    }
}
