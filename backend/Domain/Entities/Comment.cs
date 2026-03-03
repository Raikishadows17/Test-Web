using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [Column("Comment_Id")]
        public int CommentId { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column("Comment")]
        public string CommentText { get; set; } = string.Empty;

        [Column("Date")]
        public DateTime? Date { get; set; }

        // Navigation Properties
        public virtual ICollection<CustomerComment> CustomerComments { get; set; } = new List<CustomerComment>();
        public virtual ICollection<ServicesComment> ServicesComments { get; set; } = new List<ServicesComment>();
        public virtual ICollection<ProvideLogisticComments> ProvideLogisticComments { get; set; } = new List<ProvideLogisticComments>();
    }
}
