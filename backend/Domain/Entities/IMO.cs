using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    [Table("IMO")]
    public class IMO : IEntity,IActivable
    {
        [Key]
        [Column("IMO_Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Desc")]
        public string Desc { get; set; }
        [Column("Active")]
        public bool Active { get; set; } = true;
    }
}
