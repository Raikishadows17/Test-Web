using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Logistics_Provider")]
    public class LogisticsProvider : IActivable,IEntity
    {
        [Key]
        [Column("Logistics_Provider_Id")]
        public int Id { get; set; }

        [MaxLength(200)]
        [Column("Name")]
        public string? Name { get; set; }

        [MaxLength(500)]
        [Column("Full_Name")]
        public string? FullName { get; set; }

        [MaxLength(500)]
        [Column("Url_Image")]
        public string? UrlImage { get; set; }

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<Terminal> Terminals { get; set; } = new List<Terminal>();
        public virtual ICollection<EquipmentType> EquipmentTypes { get; set; } = new List<EquipmentType>();
        public virtual ICollection<ProvideLogisticComments> ProvideLogisticComments { get; set; } = new List<ProvideLogisticComments>();
        public virtual ICollection<PersonalAddress> PersonalAddresses { get; set; } = new List<PersonalAddress>();
        public virtual ICollection<PersonalContact> PersonalContacts { get; set; } = new List<PersonalContact>();
    }
}
