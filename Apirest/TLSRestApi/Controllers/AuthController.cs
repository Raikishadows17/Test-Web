using Microsoft.AspNetCore.Mvc;
using Application.Interface.Service;
using Application.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities;

namespace TLSRestApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor) 
            : base(httpContextAccessor)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                Tenant tenant = (Tenant)_httpContextAccessor.HttpContext?.Items["Tenant"];

                var result = await _authService.LoginAsync(request,tenant);
                return Ok(result);
            }
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }

        }

    }
}
