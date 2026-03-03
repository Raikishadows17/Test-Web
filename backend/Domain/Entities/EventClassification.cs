using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Event_Classification")]
    public class EventClassification : IActivable
    {
        [Key]
        [Column("Event_Classification_Id")]
        public int EventClassificationId { get; set; }

        [MaxLength(200)]
        [Column("Clasiff_Name")]
        public string? ClasiffName { get; set; }

        [MaxLength(500)]
        [Column("Clasiff_Description")]
        public string? ClasiffDescription { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        public virtual ICollection<ServicesDateEvents> ServicesDateEvents { get; set; } = new List<ServicesDateEvents>();
    }
}
