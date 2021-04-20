using System;

namespace MISA.Core.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException(string msg) : base(msg)
        {
        }

        public static void CustomerCodeRequired(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                throw new CustomerException("Mã khách hàng không thể để trống!");
            }
        }
    }
}