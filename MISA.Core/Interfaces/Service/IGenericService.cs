using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IGenericService<T>
    {
        Task<T> GetByIdAsync(string id);

        Task<T> GetByCodeAsync(string code);

        Task<List<T>> GetAllAsync();

        Task<int> AddAsync(T entity);

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(string id);
    }
}