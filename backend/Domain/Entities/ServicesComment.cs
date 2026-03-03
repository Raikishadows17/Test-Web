using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Services_Comment")]
    public class ServicesComment
    {
        [Key]
        [Column("Serv_Com_Id")]
        public int ServComId { get; set; }

        [Column("Service_Id")]
        public int ServiceId { get; set; }

        [Column("Coment_Id")]
        public int ComentId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; } = null!;

        [ForeignKey(nameof(ComentId))]
        public virtual Comment Comment { get; set; } = null!;
    }
}
