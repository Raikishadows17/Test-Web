using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.DTOs
{
    public class RoadRoutesDTO
    {
        public int RoadRoutesId { get; set; }
        public int? TerminalOrigenId { get; set; }
        public Terminal terminalOrigen { get; set; }
        public int? TerminalDestinoId { get; set; }
        public Terminal terminalDestino { get; set; }
        public string? RouteName { get; set; }
        public string? Comments { get; set; }
        public DateTime? RouteDate { get; set; }
        public decimal? TotalKms { get; set; }
        public string? EstimatedTime { get; set; }
    }
}
