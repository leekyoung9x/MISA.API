using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    /// <summary>
    /// Interface định nghĩa các dịch vụ dùng chung cho các service interface khác
    /// </summary>
    /// <typeparam name="T">class entity</typeparam>
    public interface IGenericService<T>
    {
        /// <summary>
        /// Hàm lấy ra thực thể với id truyền vào
        /// </summary>
        /// <param name="id">Mã định danh thực thể</param>
        /// <returns>Trả về thông tin thực thể - entity - T</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// Hàm lấy ra thực thể với mã truyền vào
        /// </summary>
        /// <param name="code">Mã thực thể</param>
        /// <returns>Trả về thông tin thực thể - entity - T</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        Task<T> GetByCodeAsync(string code);

        /// <summary>
        /// Hàm lấy ra danh sách thực thể
        /// </summary>
        /// <returns>Trả về danh sách thực thể</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Hàm thêm một thực thể vào db
        /// </summary>
        /// <param name="entity">Thông tin thực thể muốn thêm</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        Task<int> AddAsync(T entity);

        /// <summary>
        /// Hàm sửa một thực thể trên db
        /// </summary>
        /// <param name="entity">Thông tin thực thể muốn sửa</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        Task<int> UpdateAsync(T entity);

        /// <summary>
        /// Hàm xóa một thực thể trên db
        /// </summary>
        /// <param name="id">Mã định danh thực thể muốn xóa</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        Task<int> DeleteAsync(string id);
    }
}