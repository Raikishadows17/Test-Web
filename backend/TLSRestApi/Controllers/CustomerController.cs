using Application.DTOs;
using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerervice _Customerervice;

        public CustomerController(ICustomerervice Customerervice)
        {
            _Customerervice = Customerervice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _Customerervice.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _Customerervice.GetByIdAsync(id);
            if (result == null)
                return NotFound("Cliente no Registrado");
                
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO customer)
        {            
            await _Customerervice.AddAsync(customer);
            return Created(customer, "Cliente Creado Exitosamente");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDTO customer)
        {
            
                await _Customerervice.UpdateAsync(customer);
                return Ok(customer, "Cliente Actualizado Exitosamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _Customerervice.DeleteAsync(id);
            return NoContent("Cliente Eliminado Exitosamente");
        }
    }
}
