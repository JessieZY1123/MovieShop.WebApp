using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.ApplicationCore.Contracts.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<int> Insert(T entity);
        Task<int> DeleteAsync(int d);
        Task<int> Update(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
