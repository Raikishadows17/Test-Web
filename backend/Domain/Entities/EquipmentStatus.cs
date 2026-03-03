using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("Equipment_Status")]
    public class EquipmentStatus : IActivable, IEntity
    {
        [Key]
        [Column("EquipStatus_id")]
        public int Id { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Descr")]
        public string Descr { get; set; }        

        [Column("Active")]
        public bool Active { get; set; }

    }
}
