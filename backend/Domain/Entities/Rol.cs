using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Rol")]
    public class Rol : IActivable,IEntity
    {
        [Key]
        [Column("Rol_Id")]
        public int Id { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Descr")]
        public string? Descr { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        public virtual ICollection<UserRol> UserRoles { get; set; } = new List<UserRol>();
    }
}
