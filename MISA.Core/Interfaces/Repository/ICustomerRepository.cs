using MISA.Core.Entities;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<bool> CheckCustomerCodeExists(string code);
    }
}