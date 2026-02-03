using Domain.Entities;

namespace Application.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email, string DatabaseConnectionString);
    }
}
