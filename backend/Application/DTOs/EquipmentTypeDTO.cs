

namespace Application.DTOs
{
    public class EquipmentTypeDTO
    {        
        public int Id { get; set; }
     
        public int LogisticsProviderId { get; set; }

        public string? LoadCapacity { get; set; }

        public string? GeographicReference { get; set; }

        public string? FuelType { get; set; }

        public string? Descr { get; set; }

        public string? Name { get; set; }

        public string? UrlImage { get; set; }

        public string? Comments { get; set; }

    }
}
