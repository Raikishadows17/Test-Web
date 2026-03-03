
namespace Application.DTOs
{
    public class ContainerDTO
    {
        
        public int ContainerId { get; set; }
        public int ContainerTypeId { get; set; }
        public int ContainerRedId { get; set; }
        public int? ShippingLineId { get; set; }
        public string? Size { get; set; }
        public decimal? WeightKg { get; set; }
        public string ContainerNumber { get; set; } = string.Empty;
        public DateTime? RedEntryDate { get; set; }
        public DateTime? RedLiberationDate { get; set; }
        public string? ContainerTypeName { get; set; }
        public string? CntrDocumentRecuest { get; set; }
        public string? ArchieveRequest { get; set; }
        public string? CntrDocumentRfc { get; set; }
        public string? RfcCompany { get; set; }
        public string? CompanyName { get; set; }

        public ContainerTypeDTO ContainerType { get; set; }
                
    }
}
