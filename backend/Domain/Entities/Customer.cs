using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Customer")]
    public class Customer : IActivable,IEntity
    {
        [Key]
        [Column("Customer_Id")]
        public int Id { get; set; }

        [Column("Trip_Type_Id")]
        public int TripTypeId { get; set; }

        [Column("paymentTerm_id")]
        public int PaymentTermId { get; set; }

        [Column("Actual_Executive_id")]
        public int ActualExecutiveId { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("Nickname")]
        public string Nickname { get; set; } = string.Empty;

        [MaxLength(200)]
        [Column("Names")]
        public string? Names { get; set; }

        [MaxLength(200)]
        [Column("Middle_Name")]
        public string? MiddleName { get; set; }

        [MaxLength(200)]
        [Column("Last_Name")]
        public string? LastName { get; set; }

        [MaxLength(500)]
        [Column("Full_Name")]
        public string? FullName { get; set; }

        [MaxLength(300)]
        [Column("Company_Name")]
        public string? CompanyName { get; set; }

        [MaxLength(13)]
        [Column("Rfc_Company")]
        public string? RfcCompany { get; set; }

        [MaxLength(200)]
        [Column("Cust_Position")]
        public string? CustPosition { get; set; }

        [MaxLength(500)]
        [Column("Url_WebPage")]
        public string? UrlWebPage { get; set; }

        [MaxLength(500)]
        [Column("Url_Invoicing")]
        public string? UrlInvoicing { get; set; }

        [Column("Creation_Date")]
        public DateTime? CreationDate { get; set; }

        [Column("Modify_Date")]
        public DateTime? ModifyDate { get; set; }

        [Column("Contract_Actual")]
        public bool? ContractActual { get; set; }

        [Column("Certificated_Customer")]
        public bool? CertificatedCustomer { get; set; }

        [Column("Base_Contract")]
        public bool? BaseContract { get; set; }

        [Column("Contract_Personalized")]
        public bool? ContractPersonalized { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(TripTypeId))]
        public virtual TripType? TripType { get; set; }

        [ForeignKey(nameof(PaymentTermId))]
        public virtual PaymentTerms? PaymentTerm { get; set; }

        [ForeignKey(nameof(ActualExecutiveId))]
        public virtual Employee? ActualExecutive { get; set; }

        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
        public virtual ICollection<CustomerComment> CustomerComments { get; set; } = new List<CustomerComment>();
        public virtual ICollection<CreditCustomer> CreditCustomers { get; set; } = new List<CreditCustomer>();
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public virtual ICollection<CustomerFile> CustomerFiles { get; set; } = new List<CustomerFile>();
        public virtual ICollection<CustomerType> CustomerTypes { get; set; } = new List<CustomerType>();
        public virtual ICollection<IndustryType> IndustryTypes { get; set; } = new List<IndustryType>();
        public virtual ICollection<PersonalAddress> PersonalAddresses { get; set; } = new List<PersonalAddress>();
        public virtual ICollection<PersonalContact> PersonalContacts { get; set; } = new List<PersonalContact>();
    }
}
