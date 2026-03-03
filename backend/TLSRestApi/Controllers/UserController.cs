using Application.DTOs;
using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseApiController
    {
        private IUserService _UserService;

        public UserController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {            
            var result = await _UserService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _UserService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            await _UserService.AddAsync(user);
            return Created("Usuario Creado Exitosamente", null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO user)
        {
            await _UserService.UpdateAsync(user);
            return Ok("Usuario Actualizado Exitosamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsr(int id)
        {
            await _UserService.DeleteAsync(id);
            return Ok("Usuario Eliminado Exitosamente");
        }

    }
}
