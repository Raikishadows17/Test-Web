using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Container_Type")]
    public class ContainerType : IActivable,IEntity
    {
        [Key]
        [Column("ContainerType_Id")]
        public int Id { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string? Name { get; set; }

        [MaxLength(500)]
        [Column("Descr")]
        public string? Descr { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

    }
}
