using MISA.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<T> : IGenericService<T>
    {
        protected IGenericRepository<T> _baseRepository;

        public BaseService(IGenericRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            return await _baseRepository.AddAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(string id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<T> GetByCodeAsync(string code)
        {
            return await _baseRepository.GetByCodeAsync(code);
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}