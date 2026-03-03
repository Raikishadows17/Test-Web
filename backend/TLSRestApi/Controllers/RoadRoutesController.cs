using Application.DTOs;
using Application.Interface.Service;
using Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoadRoutesController : BaseApiController
    {
        private readonly IRoadRouteService _roadRouteService;

        public RoadRoutesController(IRoadRouteService roadRouteService)
        {
            _roadRouteService = roadRouteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _roadRouteService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _roadRouteService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] RoadRoutesDTO entity)
        {
            await _roadRouteService.AddAsync(entity);
            return Created("Road Route creado astisfactoriamente");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RoadRoutesDTO entity)
        {
            await _roadRouteService.UpdateAsync(entity);
            return Ok("Road Route actualizado satisfactoriamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _roadRouteService.DeleteAsync(id);
            return Ok("Road Route eliminado satisfactoriamente");

        }
    }
}
