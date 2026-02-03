using Application.Interface.Repository;
using Azure;
using Azure.Core;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        Dictionary<string, User> users = new Dictionary<string, User>()
        {
            { "kevin@mail.com", new User { User_id = 1, PasswordHash = "$2b$12$FiMusG28CiTnNFIQOBnxgutrY.y6ovbZINPT0IBDUw5fKvEshEg5m",Rol_id = 1 } },
            { "Ale@mail.com", new User { User_id = 2, PasswordHash = "$2b$12$FiMusG28CiTnNFIQOBnxgutrY.y6ovbZINPT0IBDUw5fKvEshEg5m",Rol_id = 2 } }
        };

        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmailAsync(string email, string DatabaseConnectionString)
        {
            if (users.TryGetValue(email, out User? user))
                return Task.FromResult<User?>(user);
            else
                throw new ArgumentException("Usuario no registrado");
        }
    }
}
