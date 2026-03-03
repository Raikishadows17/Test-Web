using Application.DTOs;
using Application.DTOs.Auth;
using Domain.Entities;

namespace Application.Interface.Service
{
    public interface IJwtGenenrator
    {
        TokenResultDTO GenerateToken(UserDTO user, string tenantId);
    }
}