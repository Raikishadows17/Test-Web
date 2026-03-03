using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("User_Rol")]
    public class UserRol
    {
        [Key]
        [Column("User_Rol_Id")]
        public int UserRolId { get; set; }

        [Column("User_Id")]
        public int UserId { get; set; }

        [Column("Rol_Id")]
        public int RolId { get; set; }

        [Column("Assign_Date")]
        public DateTime? AssignDate { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        [ForeignKey(nameof(RolId))]
        public virtual Rol Rol { get; set; } = null!;
    }
}
