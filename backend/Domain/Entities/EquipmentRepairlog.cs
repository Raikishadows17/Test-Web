using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Equipment_Repair_log")]
    public class EquipmentRepairLog
    {
        [Key]
        [Column("Equip_RepairLog_Id")]
        public int EquipRepairLogId { get; set; }

        [Column("Equipment_Id")]
        public int EquipmentId { get; set; }

        [Column("StartDate")]
        public DateTime? StartDate { get; set; }

        [Column("EndDate")]
        public DateTime? EndDate { get; set; }

        [MaxLength(500)]
        [Column("Descr")]
        public string? Descr { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        public virtual Equipment Equipment { get; set; } = null!;
    }
}
