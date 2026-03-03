using Application.DTOs;
using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TerminalController : BaseApiController
    {
        private readonly ITerminalService _terminalService;

        public TerminalController(ITerminalService terminalService)
        {
            _terminalService = terminalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTerminal()
        {
            var result = await _terminalService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTerminalById(int id)
        {
            var result = await _terminalService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTerminal([FromBody] TerminalDTO terminal)
        {
            await _terminalService.AddAsync(terminal);
            return Created("Terminal Creada Exitosamente");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTerminal([FromBody] TerminalDTO terminal)
        {
            await _terminalService.UpdateAsync(terminal);
            return Ok("Terminal Actualizada Exitosamente");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTerminal(int id)
        {
            await _terminalService.DeleteAsync(id);
            return Ok("Terminal Eliminada Exitosamente");
        }

    }
}
