using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using Domain.Entities;
using MapsterMapper;

namespace Application.Services
{
    public class Customerervice : BaseService<CustomerDTO>, ICustomerervice
    {
        private readonly ICustomerRepository _customerRepository;

        public Customerervice(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

    }
}
