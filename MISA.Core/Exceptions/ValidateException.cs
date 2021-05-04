using System;

namespace MISA.Core.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException() : base()
        {
        }

        public ValidateException(string msg) : base(msg)
        {
        }
    }
}