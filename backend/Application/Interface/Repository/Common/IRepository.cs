namespace Application.Interface.Repository.Common
{
    public interface IRepository<T> : 
                        ICreateRepository<T>
                        ,IEditableRepository<T>
                        ,IGetDataRepository<T> where T : class
    {

    }
}
