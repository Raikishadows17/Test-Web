

using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Service_Event_Type")]
    public class ServiceEventType : IActivable
    {
        [Key]
        [Column("ServiceEventTypeId")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Desc")]
        public string Desc { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

    }
}
