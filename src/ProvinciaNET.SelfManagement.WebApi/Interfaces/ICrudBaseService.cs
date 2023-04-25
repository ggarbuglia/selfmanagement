using Microsoft.AspNetCore.Mvc;

namespace ProvinciaNET.SelfManagement.WebApi.Interfaces
{
    public interface ICrudBaseService<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T?> Get(int id);
        Task<T> Post(T entity);
        Task Put(int id, T entity);
        Task Delete(int id);
    }
}
