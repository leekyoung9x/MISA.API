using System;

namespace MISA.Core.AttributeCustom
{
    /// <summary>
    /// Attribute để lấy tên hiển thị
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    [AttributeUsage(AttributeTargets.Property)]
    public class CDisplayName : Attribute
    {
        /// <summary>
        /// Thuộc tính tên hiển thị
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string Name = string.Empty;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="name"></param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public CDisplayName(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// Attribute dùng để buộc trường không được để trống!
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    [AttributeUsage(AttributeTargets.Property)]
    public class CRequired : Attribute
    {
        /// <summary>
        /// Thuộc tính thông báo khi có lỗi
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string Message = string.Empty;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="message"></param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public CRequired(string message = "")
        {
            Message = message;
        }
    }

    /// <summary>
    /// Attribute kiểm tra độ dài tối đa của trường
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    [AttributeUsage(AttributeTargets.Property)]
    public class CMaxLength : Attribute
    {
        /// <summary>
        /// Thuộc tính thông báo lỗi
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string Message = string.Empty;

        /// <summary>
        /// Thuộc tính độ dài tối đa
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public int MaxLength = 0;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="message"></param>
        /// <param name="maxLength"></param>
        public CMaxLength(string message = "", int maxLength = 0)
        {
            Message = message;
            MaxLength = maxLength;
        }
    }
}