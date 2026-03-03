using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("DateEvents_Type")]
    public class DateEventsType : IActivable
    {
        [Key]
        [Column("DateEvents_Type_Id")]
        public int DateEventsTypeId { get; set; }

        [MaxLength(200)]
        [Column("Event_Name")]
        public string? EventName { get; set; }

        [MaxLength(500)]
        [Column("Event_Description")]
        public string? EventDescription { get; set; }

        [Column("Status_Id")]
        public int StatusId { get; set; }
        
        [Column("User_Report_Id")]
        public int UserReportId { get; set; }

        [MaxLength(500)]
        [Column("Url_Event")]
        public string? UrlEvent { get; set; }

        [MaxLength(500)]
        [Column("Archieve_Event")]
        public string? ArchieveEvent { get; set; }

        [MaxLength(100)]
        [Column("Type_Receipt")]
        public string? TypeReceipt { get; set; }

        [MaxLength(100)]
        [Column("Payment_Method")]
        public string? PaymentMethod { get; set; }

        [MaxLength(100)]
        [Column("Budget_Type")]
        public string? BudgetType { get; set; }

        [Column("Amount_Established", TypeName = "decimal(18,2)")]
        public decimal? AmountEstablished { get; set; }

        [Column("Amout", TypeName = "decimal(18,2)")]
        public decimal? Amout { get; set; }

        [MaxLength(50)]
        [Column("Currency")]
        public string? Currency { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(200)]
        [Column("User_Create")]
        public string? UserCreate { get; set; }

        [Column("Date_Create")]
        public DateTime? DateCreate { get; set; }

        [MaxLength(200)]
        [Column("User_Modificate")]
        public string? UserModificate { get; set; }

        [Column("Date_Modificate")]
        public DateTime? DateModificate { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(StatusId))]
        public virtual Status? Status { get; set; }

        [ForeignKey(nameof(UserReportId))]
        public virtual User? UserReport { get; set; }

        public virtual ICollection<ServicesDateEvents> ServicesDateEvents { get; set; } = new List<ServicesDateEvents>();
    }
}
