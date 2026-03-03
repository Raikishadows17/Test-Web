using Application.DTOs;
using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogisticsProvidersController : BaseApiController
    {
        private readonly ILogisticsProviderService _logisticsProviderService;

        public LogisticsProvidersController(ILogisticsProviderService logisticsProviderService)
        {
            _logisticsProviderService = logisticsProviderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          
            var logisticsProviders = await _logisticsProviderService.GetAllAsync();
            return Ok(logisticsProviders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var logisticsProvider = await _logisticsProviderService.GetByIdAsync(id);
            return Ok(logisticsProvider);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LogicProviderDTO logisticsProviderDto)
        {
            await _logisticsProviderService.AddAsync(logisticsProviderDto);
            return Created("Proveedor creado satisfactoriamente");         
        }

        [HttpPut]
        public async Task<IActionResult> Update(LogicProviderDTO logisticsProviderDto)
        {            
            await _logisticsProviderService.UpdateAsync(logisticsProviderDto);
            return Ok("Proveedore actualizado correctamente");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {            
            await _logisticsProviderService.DeleteAsync(id);
            return Ok("Proveedor eliminado correctamente");
        }
    }
}
