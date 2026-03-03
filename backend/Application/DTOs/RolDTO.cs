using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.DTOs
{
    public class RolDTO
    {
        public int RolId { get; set; }
        public string? Name { get; set; }
        public string? Descr { get; set; }
        public string? Comments { get; set; }
    }
}
