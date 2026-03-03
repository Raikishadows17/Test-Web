using Application.DTOs;
using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContainerController : BaseApiController
    {
        private readonly IContainerService _containerService;

        public ContainerController(IContainerService containerService)
        {
            _containerService = containerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var result = await _containerService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) { 
            var result = await _containerService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContainerDTO containerDto)
        {
            await _containerService.AddAsync(containerDto);
            return Ok("Contenedor Creado correctamne");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContainerDTO containerDto )
        {
            await _containerService.UpdateAsync(containerDto);
            return Ok("Contenedor creado correctamente ");
        }

    }
}
