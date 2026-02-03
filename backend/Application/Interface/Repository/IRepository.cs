using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
    }
}
