using MISA.Core.Entities;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    /// <summary>
    /// Interface thể hiện các tác vụ cho class Customer
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        /// <summary>
        /// Hàm kiểm tra mã khách hàng đã tồn tại hay chưa
        /// </summary>
        /// <param name="code">CustomerCode - Mã khách hàng</param>
        /// <returns>Nếu đã tồn tại trả về true ngược lại là false</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public Task<bool> CheckCustomerCodeExists(string code);
    }
}