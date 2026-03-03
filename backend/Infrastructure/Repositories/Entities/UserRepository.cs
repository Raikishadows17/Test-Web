using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entities
{
    public class UserRepository : CreateRepository<UserDTO,User>, IUserRepository
    {
        private IDbContextFactory _dbContextFactory;

        public UserRepository(IDbContextFactory dbContextFactory,IMapper mapper) : base (dbContextFactory, mapper)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<UserDTO?> GetUserByUserNameAsync(string userName)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Users
                .AsNoTracking()
                .Where(u => u.Username == userName && u.Active)
                //.ProjectToType<UserDTO>()
                .Select(u => new UserDTO //We need user this becasue need get the password from db to validate the user
                {
                    User_id = u.Id,
                    Username = u.Username,
                    Password = u.Password,
                    EmployeeName = u.Employee.FullName,
                    Rol = u.UserRoles
                        .Where(ur => ur.Active)
                        .Select(ur => new UserRolDTO { RolId = ur.RolId, Name = ur.Rol.Name })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User?>> GetAllUserAsync() // will keep it as example to show how create a full query using EF
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            IEnumerable<User?> UserEntity = await dbContext.Users
                    .AsNoTracking()
                    .Where(u => u.Active)
                    .Select(u => new User
                    {
                        Id = u.Id,
                        Username = u.Username,
                        Password = u.Password,
                        EmpId = u.EmpId,
                        Employee = u.Employee != null ? new Employee
                        {
                            Id = u.Employee.Id,
                            FullName = u.Employee.FullName ?? string.Empty
                        } : null,
                        UserRoles = u.UserRoles
                        .Where(ur => ur.Active && ur.Rol != null)
                        .Select(ur => new UserRol
                        {
                            UserRolId = ur.UserRolId,
                            RolId = ur.RolId,
                            Rol = new Rol
                            {
                                Id = ur.Rol.Id,
                                Name = ur.Rol.Name ?? string.Empty
                            }
                        })
                        .ToList()
                    }).ToListAsync();

            return UserEntity;
        }

        public async override Task UpdateAsync(UserDTO entityDto)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var user = await dbContext.Users.Include(u => u.UserRoles)//-TODO mejorar el performance 
                                            .FirstOrDefaultAsync(u => u.Id == entityDto.User_id);

            if(user == null)
                throw new NotFoundException("Usuario no encontrado");

            user.Username = entityDto.Username;
            user.Password = entityDto.Password;
            user.EmpId = entityDto.Emp_id;

            var incomingRoleIds = entityDto.Rol.Select(r => r.RolId).ToHashSet();
            var currentRoleIds = user.UserRoles.Select(ur => ur.RolId).ToList();

            var rolesToRemove = user.UserRoles
                                .Where(ur => !incomingRoleIds.Contains(ur.RolId)).ToList();

            foreach (var role in rolesToRemove)
            {
                dbContext.UserRoles.Remove(role);
            }

            var rolesToAdd = incomingRoleIds.Where(id => !currentRoleIds.Contains(id));

            foreach (var roleId in rolesToAdd)
            {
                user.UserRoles.Add(new UserRol
                {
                    RolId = roleId,
                    Active = true
                });
            }

            var rowAffected = await dbContext.SaveChangesAsync();

            if (rowAffected == 0)
                throw new NotFoundException("No se aplicó la actualizacion, talvez no hay usuario asignado al id proporcionado, contacta al administrador");

        }

    }
}
