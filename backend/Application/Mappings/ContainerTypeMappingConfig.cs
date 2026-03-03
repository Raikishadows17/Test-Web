using Application.DTOs;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class ContainerTypeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ContainerType, ContainerTypeDTO>()
                .Map(dest => dest.ContainerTypeId, src => src.Id);

            config.NewConfig<ContainerTypeDTO, ContainerType>()
                .Map(dest => dest.Id, src => src.ContainerTypeId);
        }
    }
}
