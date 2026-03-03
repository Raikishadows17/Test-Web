using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Terminal")]
    public class Terminal : IActivable,IEntity
    {
        [Key]
        [Column("Terminal_Id")]
        public int Id { get; set; }

        [Column("Logistics_Provider_Id")]
        public int LogisticsProviderId { get; set; }

        [MaxLength(200)]
        [Column("Terminal")]
        public string TerminalCode { get; set; }

        [MaxLength(200)]
        [Column("Name_Terminal")]
        public string NameTerminal { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [MaxLength(500)]
        [Column("Url_Image")]
        public string? UrlImage { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        // Navigation Properties
        [ForeignKey(nameof(LogisticsProviderId))]
        public virtual LogisticsProvider? LogisticsProvider { get; set; }

        public virtual ICollection<AppointmentTerminal> AppointmentTerminals { get; set; } = new List<AppointmentTerminal>();
        public virtual ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
        public virtual ICollection<ForbiddenEmployee> ForbiddenEmployees { get; set; } = new List<ForbiddenEmployee>();
        public virtual ICollection<LayoutName> LayoutNames { get; set; } = new List<LayoutName>();
        public virtual ICollection<PersonalAddress> PersonalAddresses { get; set; } = new List<PersonalAddress>();
        public virtual ICollection<PersonalContact> PersonalContacts { get; set; } = new List<PersonalContact>();
    }
}
