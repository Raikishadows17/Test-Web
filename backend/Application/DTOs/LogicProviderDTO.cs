using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.DTOs
{
    public class LogicProviderDTO
    {
        public int LogisticsProviderId { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public string? UrlImage { get; set; }
        public string? Comments { get; set; }
    }
}
