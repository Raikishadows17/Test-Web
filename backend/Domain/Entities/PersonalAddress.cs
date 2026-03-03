using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Personal_Addresses")]
    public class PersonalAddress : IActivable
    {
        [Key]
        [Column("Personal_Addresses_Id")]
        public int PersonalAddressesId { get; set; }

        [MaxLength(100)]
        [Column("Category")]
        public string Category { get; set; }

        [Column("Emp_Id")]
        public int EmpId { get; set; }

        [Column("Terminal_Id")]
        public int TerminalId { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        [Column("Logistics_Provider_Id")]
        public int LogisticsProviderId { get; set; }

        [MaxLength(300)]
        [Column("Street_Address")]
        public string? StreetAddress { get; set; }

        [MaxLength(50)]
        [Column("Internal_Number")]
        public string? InternalNumber { get; set; }

        [MaxLength(50)]
        [Column("Exterior_Number")]
        public string? ExteriorNumber { get; set; }

        [MaxLength(200)]
        [Column("City")]
        public string? City { get; set; }

        [MaxLength(200)]
        [Column("State")]
        public string? State { get; set; }

        [MaxLength(10)]
        [Column("Zip_Code")]
        public string? ZipCode { get; set; }

        [MaxLength(100)]
        [Column("Country")]
        public string? Country { get; set; }

        [MaxLength(500)]
        [Column("Maps_Url")]
        public string? MapsUrl { get; set; }

        [MaxLength(500)]
        [Column("Full_Address")]
        public string? FullAddress { get; set; }

        [MaxLength(300)]
        [Column("Reference_1")]
        public string? Reference1 { get; set; }

        [MaxLength(300)]
        [Column("Reference_2")]
        public string? Reference2 { get; set; }

        [MaxLength(300)]
        [Column("Reference_3")]
        public string? Reference3 { get; set; }

        [MaxLength(300)]
        [Column("Reference_4")]
        public string? Reference4 { get; set; }

        [MaxLength(50)]
        [Column("Maps_Lat")]
        public string? MapsLat { get; set; }

        [MaxLength(50)]
        [Column("Maps_Long")]
        public string? MapsLong { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(EmpId))]
        public virtual Employee? Employee { get; set; }

        [ForeignKey(nameof(TerminalId))]
        public virtual Terminal? Terminal { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }

        [ForeignKey(nameof(LogisticsProviderId))]
        public virtual LogisticsProvider? LogisticsProvider { get; set; }
    }
}
