using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Road_Routes")]
    public class RoadRoutes : IActivable,IEntity
    {
        [Key]
        [Column("Road_Routes_Id")]
        public int Id { get; set; }

        [Column("Terminal_Origen_Id")]
        public int TerminalOrigenId { get; set; }

        [Column("Terminal_Destino_Id")]
        public int TerminalDestinoId { get; set; }

        [MaxLength(200)]
        [Column("Route_Name")]
        public string? RouteName { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        [Column("Route_Date")]
        public DateTime? RouteDate { get; set; }

        [Column("Total_Kms", TypeName = "decimal(18,2)")]
        public decimal? TotalKms { get; set; }

        [MaxLength(100)]
        [Column("Estimated_Time")]
        public string? EstimatedTime { get; set; }

        [ForeignKey(nameof(TerminalOrigenId))]
        public virtual Terminal? TerminalOrigen { get; set; }

        [ForeignKey(nameof(TerminalDestinoId))]
        public virtual Terminal? TerminalDestino { get; set; }

        public virtual ICollection<RoutesServices> RoutesServices { get; set; } = new List<RoutesServices>();
    }
}
