using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.DTOs
{
    public class IMODto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
