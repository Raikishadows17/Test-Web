using Application.DTOs;
using Application.Interface.Service;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolController : BaseApiController
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRol()
        {
            var result = await _rolService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById(int id)
        {
            var result = await _rolService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRol([FromBody] RolDTO roldto)
        {
            await _rolService.AddAsync(roldto);
            return Created("Rol Creado Satisfactoriamente");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRol([FromBody] RolDTO roldto)
        {
            await _rolService.UpdateAsync(roldto);
            return Ok("Rol actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            await _rolService.DeleteAsync(id);
            return Ok("Rol Eliminado");
        }

    }
}
