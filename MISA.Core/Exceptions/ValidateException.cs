using System;

namespace MISA.Core.Exceptions
{
    /// <summary>
    /// Exception bắt lỗi cho tất cả các loại kiểm tra dữ liệu
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class ValidateException : Exception
    {
        /// <summary>
        /// Hàm khởi tạo không tham số
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public ValidateException() : base()
        {
        }

        /// <summary>
        /// Hàm khởi tạo có tham số
        /// </summary>
        /// <param name="msg">Thông báo lỗi</param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public ValidateException(string msg) : base(msg)
        {
        }
    }
}