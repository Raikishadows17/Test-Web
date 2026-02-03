using Application.DTOs.Auth;
using Domain.Entities;

namespace Application.Interface.Service
{
    public interface IJwtGenenrator
    {
        TokenResult GenerateToken(User user, string tenantId);
    }
}