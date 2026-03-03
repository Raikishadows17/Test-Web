using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Repository.Common
{
    public interface IEditableRepository<T> where T : class
    {
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
