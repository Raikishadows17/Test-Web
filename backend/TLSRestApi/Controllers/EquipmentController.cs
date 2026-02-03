using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : BaseApiController
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetEquipment()
        {
            try
            {
                var equipmentList = await _equipmentService.GetAllEquipmentAsync();
                return Ok(equipmentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
