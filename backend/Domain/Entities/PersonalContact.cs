using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Personal_Contact")]
    public class PersonalContact : IActivable
    {
        [Key]
        [Column("Personal_Contact_Id")]
        public int PersonalContactId { get; set; }

        [Column("Emp_Id")]
        public int EmpId { get; set; }

        [Column("Terminal_Id")]
        public int TerminalId { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        [Column("Logistics_Provider_Id")]
        public int LogisticsProviderId { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Value")]
        public string Value { get; set; }

        [Column("Certificated")]
        public bool Certificated { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [Column("Date_Create")]
        public DateTime? DateCreate { get; set; }

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
