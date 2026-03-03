using Application.DTOs.Auth;
using Domain.Common;
using Domain.Entities;

namespace Application.Interface.Service
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request);
    }
}
