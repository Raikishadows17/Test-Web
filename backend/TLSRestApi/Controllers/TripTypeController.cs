using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TripTypeController : BaseApiController
    {
        private readonly ITripTypeService _tripTypeService;

        public TripTypeController(ITripTypeService tripTypeService)
        {
            _tripTypeService = tripTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _tripTypeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _tripTypeService.GetByIdAsync(id);
            return Ok(result);
        }

    }
}
