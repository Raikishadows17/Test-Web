using Application.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    internal class EquipmentMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Equipment, EquipmentDTO>()
                .Map(dest => dest.EquipmentId, src => src.Id)
                .Map(dest => dest.EquipmentType, src => src.EquipmentType)
                .Map(dest => dest.TripType, src => src.TripType)
                .Map(dest => dest.Terminal, src => src.Terminal)
                .Map(dest => dest.EquipmentStatus,src => src.EquipmentStatus );

            config.NewConfig<EquipmentDTO, Equipment>()
                .Map(dest => dest.Id, src => src.EquipmentId)
                .Ignore(dest => dest.Active)
                .Map(dest => dest.EquipmentType,src => src.EquipmentType)
                .Map(dest => dest.Terminal , src => src.Terminal)
                .Map(dest => dest.TripType , src => src.TripType)
                .Map(dest => dest.EquipmentStatus, src => src.EquipmentStatus)
                .Ignore(dest => dest.AssignedEquipments)
                .Ignore(dest => dest.EquipmentFiles)
                .Ignore(dest => dest.EquipmentRepairLogs);
        }
    }
}
