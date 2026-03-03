

using Application.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    public class TripTypeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TripType, TripTypeDTO>()
           .Map(dest => dest.TripTypeId, src => src.Id);

            config.NewConfig<TripTypeDTO, TripType>()
                .Map(dest => dest.Id, src => src.TripTypeId);
        }
    }
}
