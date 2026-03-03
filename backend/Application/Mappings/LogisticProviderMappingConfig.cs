using Application.DTOs;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    internal class LogisticProviderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LogisticsProvider, LogicProviderDTO>()
                .Map(dest => dest.LogisticsProviderId, src => src.Id);

            config.NewConfig<LogicProviderDTO, LogisticsProvider>()
                .Map(dest => dest.Id, src => src.LogisticsProviderId)
                .Ignore(dest => dest.Active)
                .Ignore(dest => dest.Terminals)
                .Ignore(dest => dest.EquipmentTypes)
                .Ignore(dest => dest.ProvideLogisticComments)
                .Ignore(dest => dest.PersonalAddresses)
                .Ignore(dest => dest.PersonalContacts);
        }
    }
}
