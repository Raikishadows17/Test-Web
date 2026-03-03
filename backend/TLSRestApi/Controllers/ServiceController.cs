using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceController : BaseApiController
    {
        private IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _serviceService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _serviceService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("ServiceCreationOption")]
        public async Task<IActionResult> GetServiceOptionConfig()
        {
            var result = await _serviceService.GetServiceCreationOptionAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceDTO entity)
        {
            await _serviceService.AddAsync(entity);
            return Created("Servicio Creado Satisfactoriamente");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ServiceDTO entity)
        {
            await _serviceService.UpdateAsync(entity);
            return Ok("Servicio Actualizado Correctamente");
        }

    }
}
