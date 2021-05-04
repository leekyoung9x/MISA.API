using MISA.Core.AttributeCustom;
using MISA.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Guid? CustomerId { get; set; }

        public string CustomerCode { get; set; }

        //[DisplayName("Họ và tên")]
        //[Display(Name = "Họ và tên")]
        //[Required(ErrorMessage = "{0} không thể để trống!")]
        [CDisplayName("Họ và tên")]
        [CRequired()]
        public string FullName { get; set; }

        public Gender Gender { get; set; }
        public string MemberCardCode { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }
        public string Note { get; set; }
    }
}