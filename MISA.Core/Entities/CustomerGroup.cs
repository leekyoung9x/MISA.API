using MISA.Core.AttributeCustom;
using System;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Class thể hiện cho bảng CustomerGroup trong db
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class CustomerGroup : BaseEntity
    {
        /// <summary>
        /// Thuộc tính định danh mã nhóm khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Thuộc tính tên nhóm khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        [CDisplayName("Nhóm khách hàng")]
        [CRequired]
        [CMaxLength(maxLength: 5)]
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Thuộc tính mô tả cho nhóm khách hàng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        [CDisplayName("Mô tả nhóm khách hàng")]
        [CRequired]
        public string Description { get; set; }

        /// <summary>
        /// Cái này db có @@???
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string ParentId { get; set; }
    }
}