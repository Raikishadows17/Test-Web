using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Equipment_Type")]
    public class EquipmentType : IActivable,IEntity
    {
        [Key]
        [Column("EquipType_id")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column("Fuel_Type")]
        public string? FuelType { get; set; }

        [MaxLength(500)]
        [Column("Descr")]
        public string? Descr { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string? Name { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

    }
}
