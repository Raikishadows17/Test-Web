using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Repository.Common
{
    public interface ICreateRepository<T> where T : class
    {
        Task AddAsync(T entity);
    }
}
