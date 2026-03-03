using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.DTOs
{
    public class TerminalDTO
    {
        public int TerminalId { get; set; }
        public int? LogisticsProviderId { get; set; }
        public string? TerminalCode { get; set; }
        public string? NameTerminal { get; set; }
        public string? Comments { get; set; }
        public string? UrlImage { get; set; }
    }
}
