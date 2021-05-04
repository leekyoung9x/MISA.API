using MISA.Core.AttributeCustom;
using MISA.Core.Exceptions;
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

        public async Task<int> AddAsync(T entity)
        {
            Validate(entity);
            return await _baseRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<T> GetByCodeAsync(string code)
        {
            return await _baseRepository.GetByCodeAsync(code);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

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

        public virtual void CustomValidate(T entity)
        {
        }
    }
}