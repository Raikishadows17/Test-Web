using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Industry_Type")]
    public class IndustryType : IActivable
    {
        [Key]
        [Column("Industry_Type_Id")]
        public int IndustryTypeId { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        [MaxLength(200)]
        [Column("Industry_Type")]
        public string? IndustryTypeName { get; set; }

        [MaxLength(500)]
        [Column("Desc")]
        public string? Desc { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;
    }
}
