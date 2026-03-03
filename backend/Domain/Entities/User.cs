using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("User")]
    public class User : IActivable,IEntity
    {
        [Key]
        [Column("User_Id")]
        public int Id { get; set; }

        [Column("Emp_Id")]
        public int EmpId { get; set; }

        [MaxLength(200)]
        [Column("Username")]
        public string Username { get; set; }

        [MaxLength(500)]
        [Column("Password")]
        public string Password { get; set; }

        [MaxLength(500)]
        [Column("Token_id")]
        public string? TokenId { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(EmpId))]
        public virtual Employee? Employee { get; set; }

        public virtual ICollection<UserRol> UserRoles { get; set; } = new List<UserRol>();
    }
}
