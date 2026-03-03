using Application.DTOs;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    internal class RolMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Rol, RolDTO>()
                .Map(dest => dest.RolId, src => src.Id);

            config.NewConfig<RolDTO, Rol>()
                .Map(dest => dest.Id, src => src.RolId)
                .Ignore(dest => dest.Active)
                .Ignore(dest => dest.UserRoles);
        }
    }
}
