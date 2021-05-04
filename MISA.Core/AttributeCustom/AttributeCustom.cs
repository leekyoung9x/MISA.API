using System;

namespace MISA.Core.AttributeCustom
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CDisplayName : Attribute
    {
        public string Name = string.Empty;

        public CDisplayName(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CRequired : Attribute
    {
        public string Message = string.Empty;

        public CRequired(string message = "")
        {
            Message = message;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CMaxLength : Attribute
    {
        public string Message = string.Empty;
        public int MaxLength = 0;

        public CMaxLength(string message = "", int maxLength = 0)
        {
            Message = message;
            MaxLength = maxLength;
        }
    }
}