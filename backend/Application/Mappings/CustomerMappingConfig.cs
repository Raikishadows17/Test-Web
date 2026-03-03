using Application.DTOs;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    internal class CustomerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Customer, CustomerDTO>()
                .Map(dest => dest.CustomerId, src => src.Id);

            config.NewConfig<CustomerDTO, Customer>()
                .Map(dest => dest.Id, src => src.CustomerId)
                .Ignore(dest => dest.Active)
                .Ignore(dest => dest.TripType)
                .Ignore(dest => dest.PaymentTerm)
                .Ignore(dest => dest.ActualExecutive)
                .Ignore(dest => dest.Services)
                .Ignore(dest => dest.CustomerComments)
                .Ignore(dest => dest.CreditCustomers)
                .Ignore(dest => dest.Contracts)
                .Ignore(dest => dest.CustomerFiles)
                .Ignore(dest => dest.CustomerTypes)
                .Ignore(dest => dest.IndustryTypes)
                .Ignore(dest => dest.PersonalAddresses)
                .Ignore(dest => dest.PersonalContacts);
        
        }
    }
}
