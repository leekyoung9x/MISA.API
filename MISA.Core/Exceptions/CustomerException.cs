using System;

namespace MISA.Core.Exceptions
{
    /// <summary>
    /// Exception thiết kế riêng cho class Customer
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class CustomerException : Exception
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="msg"></param>
        public CustomerException(string msg) : base(msg)
        {
        }
    }
}