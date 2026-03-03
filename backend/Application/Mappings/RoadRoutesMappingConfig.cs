using Application.DTOs;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    internal class RoadRoutesMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RoadRoutes, RoadRoutesDTO>()
               .Map(dest => dest.RoadRoutesId, src => src.Id)
               .Map(dest => dest.terminalOrigen, src => src.TerminalOrigen)
               .Map(dest => dest.terminalDestino, src => src.TerminalDestino);

            config.NewConfig<RoadRoutesDTO, RoadRoutes>()
                .Map(dest => dest.Id, src => src.RoadRoutesId)
                .Ignore(dest => dest.Active)
                .Map(dest => dest.TerminalOrigen, src => src.terminalOrigen)
                .Map(dest => dest.TerminalDestino, src => src.terminalDestino)
                .Ignore(dest => dest.RoutesServices);

        }
    }
}
