using MISA.Core.AttributeCustom;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    /// <summary>
    /// Class dùng chung với các tác vụ chung cho các class entity
    /// </summary>
    /// <typeparam name="T">Class entity</typeparam>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class BaseService<T> : IGenericService<T>
    {
        /// <summary>
        /// Interface dùng chung cho repository
        /// </summary>
        protected IGenericRepository<T> _baseRepository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseRepository">Tham số là interface dùng chung cho repository</param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public BaseService(IGenericRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Hàm thêm một thực thể vào db
        /// </summary>
        /// <param name="entity">Thông tin thực thể muốn thêm</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public async Task<int> AddAsync(T entity)
        {
            Validate(entity);
            return await _baseRepository.AddAsync(entity);
        }

        /// <summary>
        /// Hàm xóa một thực thể trên db
        /// </summary>
        /// <param name="id">Mã định danh thực thể muốn xóa</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public async Task<int> DeleteAsync(string id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Hàm lấy ra danh sách thực thể
        /// </summary>
        /// <returns>Trả về danh sách thực thể</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public async Task<List<T>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        /// <summary>
        /// Hàm lấy ra thực thể với mã truyền vào
        /// </summary>
        /// <param name="code">Mã thực thể</param>
        /// <returns>Trả về thông tin thực thể - entity - T</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public async Task<T> GetByCodeAsync(string code)
        {
            return await _baseRepository.GetByCodeAsync(code);
        }

        /// <summary>
        /// Hàm lấy ra thực thể với id truyền vào
        /// </summary>
        /// <param name="id">Mã định danh thực thể</param>
        /// <returns>Trả về thông tin thực thể - entity - T</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public async Task<T> GetByIdAsync(string id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Hàm sửa một thực thể trên db
        /// </summary>
        /// <param name="entity">Thông tin thực thể muốn sửa</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public async Task<int> UpdateAsync(T entity)
        {
            Validate(entity);
            return await _baseRepository.UpdateAsync(entity);
        }

        private void Validate(T entity)
        {
            // Lấy ra các thuộc tính của thực thể
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var displayName = "";
                // Lấy display name
                var displayNameValidate = property.GetCustomAttributes(typeof(CDisplayName), true);
                if (displayNameValidate.Length > 0)
                {
                    displayName = (displayNameValidate[0] as CDisplayName).Name;
                }
                if (string.IsNullOrEmpty(displayName))
                {
                    displayName = property.Name;
                }
                // Check không thể để trống
                var requiredValidate = property.GetCustomAttributes(typeof(CRequired), true);
                if (requiredValidate.Length > 0)
                {
                    // Lấy giá trị
                    var propertyValue = property.GetValue(entity);
                    // Kiểm tra giá trị
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var msgError = (requiredValidate[0] as CRequired).Message;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            //msgError = $"Thông tin {property.Name} không được phép để trống!";
                            msgError = string.Format(Properties.ValidateResource.REQUIRED_MESSAGE, displayName);
                        }
                        throw new ValidateException(msgError);
                    }
                }

                // Check chiều dài
                var maxLengthRequired = property.GetCustomAttributes(typeof(CMaxLength), true);
                if (maxLengthRequired.Length > 0)
                {
                    // Lấy giá trị
                    var propertyValueLength = property.GetValue(entity).ToString().Length;
                    var maxLength = (maxLengthRequired[0] as CMaxLength).MaxLength;
                    // Kiểm tra giá trị
                    if (propertyValueLength > maxLength)
                    {
                        var msgError = (maxLengthRequired[0] as CMaxLength).Message;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            //msgError = $"Thông tin {property.Name} không được vượt quá {maxLength} kí tự!";
                            msgError = string.Format(Properties.ValidateResource.MAXLENGTH_MESSAGE, displayName, maxLength);
                        }
                        throw new ValidateException(msgError);
                    }
                }
            }

            // UNDONE: Thêm các validate về email, password!
            CustomValidate(entity);
        }

        /// <summary>
        /// Hàm kiểm tra cho coder override
        /// </summary>
        /// <param name="entity">Thông tin thực thể</param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public virtual void CustomValidate(T entity)
        {
        }
    }
}