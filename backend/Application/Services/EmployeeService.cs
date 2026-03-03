using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using Domain.Exceptions;

namespace Application.Services
{
    public class EmployeeService :BaseService<EmployeeDTO>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeService(IEmployeeRepository employeeRepository) :base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllOperatorsAsync()
        {
            return await _employeeRepository.GetAllOperatorsAsync();
        }
    }
}
