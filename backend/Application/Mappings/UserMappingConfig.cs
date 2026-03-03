using Application.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDTO>().Map(dest => dest.User_id, src => src.Id)
                                             .Map(dest => dest.Emp_id, src => src.EmpId)
                                             .Map(dest => dest.Username, src => src.Username ?? string.Empty)
                                             .Map(dest => dest.Password, src => string.Empty)
                                             .Map(dest => dest.EmployeeName,src => src.Employee.FullName)
                                             .Map(dest => dest.Rol, src => src.UserRoles.Select(ur => new UserRolDTO {
                                                                                                            RolId = ur.Rol.Id
                                                                                                            ,Name = ur.Rol.Name 
                                                                                                             }).ToList() );
            config.NewConfig<UserDTO,User>().Ignore(dest => dest.Id)
                .Ignore(dest => dest.UserRoles)
                .Map(dest => dest.EmpId, src => src.Emp_id)
                .Map(dest => dest.Active, _ => true);
        }
    }
}
