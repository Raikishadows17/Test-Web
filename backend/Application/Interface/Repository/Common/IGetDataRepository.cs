using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Repository.Common
{
    public interface IGetDataRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
