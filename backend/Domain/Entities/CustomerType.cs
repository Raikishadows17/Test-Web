using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Customer_Type")]
    public class CustomerType : IActivable
    {
        [Key]
        [Column("Customer_Type_Id")]
        public int CustomerTypeId { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        [Column("Cust_Parent_FF")]
        public int CustParentFF { get; set; }

        [MaxLength(200)]
        [Column("Invoicing_CF")]
        public string? InvoicingCF { get; set; }

        [MaxLength(200)]
        [Column("Invoicing_FF")]
        public string? InvoicingFF { get; set; }

        [MaxLength(100)]
        [Column("Cust_Type")]
        public string? CustType { get; set; }

        [MaxLength(500)]
        [Column("Cust_Type_Desc")]
        public string? CustTypeDesc { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(CustParentFF))]
        public virtual Customer? ParentCustomer { get; set; }
    }
}
