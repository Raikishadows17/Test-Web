
namespace Application.Interface.Service.Common
{
    public interface IGetDataService <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
