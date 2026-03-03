using Application.DTOs;
using Application.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : BaseApiController
    {
        private IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _EmployeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await _EmployeeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _EmployeeService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("Operator")]
        public async Task<IActionResult> GetAllOperatorAsync()
        {
            var result = await _EmployeeService.GetAllOperatorsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employee)
        {
            await _EmployeeService.AddAsync(employee);
            return Created("Empleado Creado Exitosamente");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDTO employee)
        {
                await _EmployeeService.UpdateAsync(employee);
                return Ok("Empleado Actualizado Exitosamente");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
                await _EmployeeService.DeleteAsync(id);
                return Ok("Empleado Eliminado Exitosamente");
        }
    }
}
