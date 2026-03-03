using Application.DTOs;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    internal class ContainerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Container, ContainerDTO>()
               .Map(dest => dest.ContainerId, src => src.Id)
               .Map(dest => dest.ContainerType, src => src.ContainerType);

            config.NewConfig<ContainerDTO, Container>()
                .Map(dest => dest.Id, src => src.ContainerId)
                .Ignore(dest => dest.Active)
                .Map(dest => dest.ContainerType, src => src.ContainerType)
                .Ignore(dest => dest.ContainerRed)
                .Ignore(dest => dest.ShippingLine)
                .Ignore(dest => dest.ContainerSeals)
                .Ignore(dest => dest.Services)
                .Ignore(dest => dest.FullEmpties)
                .Ignore(dest => dest.SchedulededAppointments);

        }
    }
}
