using Application.DTOs;
using Application.Interface.Service;
using Application.Interface.Repository;
using Application.DTOs.Auth;
using Domain.Entities;
using System.Diagnostics;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITenantService _tenantService;
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenenrator _jwtGenenrator;

        public AuthService(ITenantService tenantService, IUserRepository userRepository , IJwtGenenrator jwtGenenrator)
        {
            _tenantService = tenantService;
            _userRepository = userRepository;
            _jwtGenenrator = jwtGenenrator;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request, Tenant tenant)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(request.Email, tenant.DatabaseConnectionString);

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                    throw new Exception("Credenciales Invalidas");

                var token = _jwtGenenrator.GenerateToken(user, tenant.TenantId);

                return new LoginResponse
                {
                    Token = token.Token,
                    TokenExpiration = token.Expiration,
                    Usuario = new UserDTO
                    {
                        User_id = user.User_id,
                        Rol_id = user.Rol_id,
                        Emp_id = user.Emp_id
                    }
                };

            }
            catch (Exception ex)
            {
                throw new Exception("Error en el login: " + ex.Message);
            }
        }
    }
}
