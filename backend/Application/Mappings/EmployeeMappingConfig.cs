using Application.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    internal class EmployeeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Employee, EmployeeDTO>()
                  .Map(dest => dest.EmpId, src => src.Id)
                  .Map(dest => dest.employeeCategory, src => src.EmployeeCategory);

            config.NewConfig<EmployeeDTO, Employee>()
                .Map(dest => dest.Id, src => src.EmpId)
                .Ignore(dest => dest.Active)
                .Map(dest => dest.EmployeeCategory, src => src.employeeCategory  )
                .Ignore(dest => dest.Users)
                .Ignore(dest => dest.AssignedOperators)
                .Ignore(dest => dest.EmployeeDisableds)
                .Ignore(dest => dest.ForbiddenEmployees)
                .Ignore(dest => dest.PersonalAddresses)
                .Ignore(dest => dest.PersonalContacts);
        }
    
    }
}
