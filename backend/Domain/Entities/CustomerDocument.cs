using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Customer_Document")]
    public class CustomerDocument : IActivable
    {
        [Key]
        [Column("Cust_Doc_Id")]
        public int CustDocId { get; set; }

        [MaxLength(100)]
        [Column("Type")]
        public string? Type { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string? Name { get; set; }

        [MaxLength(500)]
        [Column("Description")]
        public string? Description { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        public virtual ICollection<CustomerFile> CustomerFiles { get; set; } = new List<CustomerFile>();
    }
}
