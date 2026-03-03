using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using MapsterMapper;

namespace Infrastructure.Repositories.Entities
{
    public class CustomerRepository : CreateRepository<CustomerDTO,Customer>, ICustomerRepository
    {
        public readonly IDbContextFactory _dbContextFactory;

        public CustomerRepository(IDbContextFactory dbContextFactory,IMapper mapper) : base (dbContextFactory,mapper)
        {
            _dbContextFactory = dbContextFactory;
        }      

        public async override Task UpdateAsync(CustomerDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
