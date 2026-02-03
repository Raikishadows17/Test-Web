using Application.Interface.Repository;
using Application.Interface.Service;
using Domain.Entities;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await _customerRepository.GetAllAsync();
        }
    }
}
