using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using Domain.Common;
using Domain.Entities;
using Domain.Exceptions;
using MapsterMapper;

namespace Application.Services
{
    public class UserService :BaseService<UserDTO>, IUserService
    {
        private IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository) : base (userRepository)
        {
            _userRepository = userRepository;
        }

    }
}
