using Application.DTOs;
using Application.DTOs.Auth;
using Application.Interface.Context;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITenantContext _tenantContext;
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenenrator _jwtGenenrator;

        public AuthService(IUserRepository userRepository , IJwtGenenrator jwtGenenrator,ITenantContext tenantContext)
        {
            _tenantContext = tenantContext;
            _userRepository = userRepository;
            _jwtGenenrator = jwtGenenrator;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            try
            {
                var user = await _userRepository.GetUserByUserNameAsync(request.UserName);
                if (user == null)
                    throw new NotFoundException("Usuario no registrado");

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                    throw new UnauthorizedAccessException("Credenciales Invalidas");

                if (user.Rol.Count == 0)
                    throw new UnauthorizedAccessException("Usuario no cuenta con rol valido");

                var tenant = _tenantContext.GetTenant();

                var token = _jwtGenenrator.GenerateToken(user, tenant.TenantName);

                user.Password = string.Empty; // Limpiar la contraseña antes de devolver el usuario

                return new LoginResponseDTO
                {
                    Token = token.Token,
                    TokenExpiration = token.Expiration,
                    Usuario = user
                };

            }
            catch (Exception ex)
            {
                throw new Exception("Error en el login: " + ex.Message);
            }
        }
    }
}
