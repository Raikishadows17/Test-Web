using Application.Interface.Service;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs.Auth;

namespace Infrastructure.Security
{
    public class JwtGenenrator : IJwtGenenrator
    {
        private readonly IConfiguration _configuration;
        public JwtGenenrator(IConfiguration configuration) 
            => _configuration = configuration;

        public TokenResult GenerateToken(User user, string tenantId)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"]
                ?? throw new Exception("SecretKey no configurado");

            var issuer = _configuration["JwtSettings:Issuer"]
                ?? throw new Exception("Issuer no configurado");

            var audience = _configuration["JwtSettings:Audience"]
                ?? throw new Exception("Audience no configurado");

            //var expireHours = int.TryParse(_configuration["JwtSettings:ExpireHours"], out var hours);
            var expireHours = int.TryParse(
                    _configuration["JwtSettings:ExpireHours"],
                    out var hours) ? hours : 8;

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.User_id.ToString()),
            new Claim("Rol_Id" , user.Rol_id.ToString()),
            new Claim("Emp_Id" , user.Emp_id.ToString()),
            new Claim("TenantId", tenantId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(expireHours);

            var token = new JwtSecurityToken(
                claims: claims,
                
                issuer: issuer,
                audience: audience,
                expires: expiration,
                signingCredentials: credentials
            );

            return new TokenResult()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
