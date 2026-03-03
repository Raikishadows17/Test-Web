using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("ProvideLogistic_Comments")]
    public class ProvideLogisticComments
    {
        [Key]
        [Column("ProvideLog_Comment_Id")]
        public int ProvideLogCommentId { get; set; }

        [Column("Comment_Id")]
        public int CommentId { get; set; }

        [Column("ProvLog_Id")]
        public int ProvLogId { get; set; }

        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; } = null!;

        [ForeignKey(nameof(ProvLogId))]
        public virtual LogisticsProvider LogisticsProvider { get; set; } = null!;
    }
}
