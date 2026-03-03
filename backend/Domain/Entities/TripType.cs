using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Trip_Type")]
    public class TripType : IEntity,IActivable
    {
        [Key]
        [Column("Trip_Type_Id")]
        public int Id { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Desc")]
        public string? Desc { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

    }
}
