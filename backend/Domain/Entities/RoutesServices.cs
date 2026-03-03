using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Routes_Services")]
    public class RoutesServices : IActivable
    {
        [Key]
        [Column("Routes_Services_Id")]
        public int RoutesServicesId { get; set; }

        [Column("Road_Routes_Id")]
        public int RoadRoutesId { get; set; }

        [Column("Service_Id")]
        public int ServiceId { get; set; }

        [Column("Route_Ini_Date")]
        public DateTime? RouteIniDate { get; set; }

        [Column("Route_End_Date")]
        public DateTime? RouteEndDate { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [ForeignKey(nameof(RoadRoutesId))]
        public virtual RoadRoutes RoadRoute { get; set; } = null!;

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; } = null!;        

    }
}
