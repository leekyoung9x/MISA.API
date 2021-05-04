using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.AttributeCustom
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