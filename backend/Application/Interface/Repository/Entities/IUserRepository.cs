using Application.DTOs;
using Application.Interface.Repository.Common;
using Domain.Entities;

namespace Application.Interface.Repository.Entities
{
    public interface IUserRepository :IRepository<UserDTO>
    {
        Task<UserDTO?> GetUserByUserNameAsync(string userName);
        Task<IEnumerable<User?>> GetAllUserAsync();
    }
}
