using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Status_Service")]
    public class StatusService
    {
        [Key]
        [Column("StatusServiceId")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Descr")]
        public string Desc { get; set; }

        [Column("Classification")]
        public string Clasification { get; set; }

        [Column("Sequence")]
        public int Sequence { get; set; }

    }
}
