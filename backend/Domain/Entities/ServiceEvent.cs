using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("Service_Event")]
    public class ServiceEvent
    {
        [Key]
        [Column("ServiceEventId")]
        public int Id { get; set; }

        [Column("ServiceEventTypeId")]
        public int ServiceEventTypeId { get; set; }

        [Column("Desc")]
        public string Desc { get; set; }

        [ForeignKey(nameof(ServiceEventTypeId))]
        public virtual ServiceEventType? ServiceEventType { get; set; }

    }
}
