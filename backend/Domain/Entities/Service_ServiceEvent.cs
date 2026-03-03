using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("Service_ServiceEvent")]
    public class Service_ServiceEvent
    {
        [Key]
        [Column("Service_ServiceEvent_Id")]
        public int id { get; set; }

        [Column("ServiceEventId")]
        public int ServiceEventId { get; set; }

        [Column("Service_Id")]
        public int ServiceId { get; set; }

        [Column("Comments")]
        public string Comments { get; set; }

        [ForeignKey(nameof(ServiceEventId))]
        public virtual ServiceEvent Event { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Services { get; set; }
    }
}
