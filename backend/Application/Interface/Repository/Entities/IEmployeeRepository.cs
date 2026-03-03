using Application.DTOs;
using Application.Interface.Repository.Common;

namespace Application.Interface.Repository.Entities
{
    public interface IEmployeeRepository : IRepository<EmployeeDTO>
    {
        Task<IEnumerable<EmployeeDTO>> GetAllOperatorsAsync();
    }
}
