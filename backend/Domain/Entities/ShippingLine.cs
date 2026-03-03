using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Shipping_Line")]
    public class ShippingLine : IActivable
    {
        [Key]
        [Column("Shipping_Line_Id")]
        public int ShippingLineId { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Description")]
        public string? Description { get; set; }

        [MaxLength(100)]
        [Column("Short_Name")]
        public string? ShortName { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        public virtual ICollection<Container> Containers { get; set; } = new List<Container>();
    }
}
