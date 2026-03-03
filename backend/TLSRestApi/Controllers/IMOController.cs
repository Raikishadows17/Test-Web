using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IMOController : BaseApiController
    {
        private readonly IIMOService _imoService;

        public IMOController(IIMOService imoService)
        {
            _imoService = imoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() { 
            var result = await _imoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _imoService.GetByIdAsync(id);
            return Ok(result);
        }

    }
}
