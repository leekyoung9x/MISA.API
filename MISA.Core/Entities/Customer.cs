using MISA.Core.AttributeCustom;
using MISA.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Class thể hiện của bảng Customer trong db
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class Customer : BaseEntity
    {
        /// <summary>
        /// Thuộc tính mã định danh khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Thuộc tính mã khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string CustomerCode { get; set; }

        /// <summary>
        /// Thuộc tính tên khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        [CDisplayName("Họ và tên")]
        [CRequired()]
        public string FullName { get; set; }

        /// <summary>
        /// Thuộc tính giới tính khách hàng
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Thuộc tính mã thẻ thành viên
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Thuộc tính mã định danh nhóm khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Thuộc tính số điện thoại khác hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Thuộc tính ngày sinh khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Thuộc tính tên công ty khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string CompanyName { get; set; }

        /// <summary>
        /// Thuộc tính mã tax công ty
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Thuộc tính email khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Thuộc tính địa chỉ khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string Address { get; set; }

        /// <summary>
        /// Thuộc tính ghi chú
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string Note { get; set; }
    }
}