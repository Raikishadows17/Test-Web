using Application.DTOs;
using Application.Interface.Repository.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Repository.Entities
{
    public interface ICustomerRepository : IRepository<CustomerDTO>
    {
    }
}
