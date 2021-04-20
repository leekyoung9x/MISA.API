using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException(string msg) : base(msg)
        {
        }
    }
}