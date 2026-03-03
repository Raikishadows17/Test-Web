using Application.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    internal class TerminalMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Terminal, TerminalDTO>()
                 .Map(dest => dest.TerminalId, src => src.Id);

            config.NewConfig<TerminalDTO, Terminal>()
                .Map(dest => dest.Id, src => src.TerminalId)
                .Ignore(dest => dest.Active)
                .Ignore(dest => dest.LogisticsProvider)
                .Ignore(dest => dest.AppointmentTerminals)
                .Ignore(dest => dest.Equipments)
                .Ignore(dest => dest.ForbiddenEmployees)
                .Ignore(dest => dest.LayoutNames)
                .Ignore(dest => dest.PersonalAddresses)
                .Ignore(dest => dest.PersonalContacts);
        }
    }
}
