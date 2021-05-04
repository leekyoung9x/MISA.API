using System;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Class với những thuộc tính bắt buộc dùng chung cho các entity
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class BaseEntity
    {
        /// <summary>
        /// Thuộc tính ngày tạo
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Thuộc tính người tạo
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string CreatedBy { get; set; }

        /// <summary>
        /// Thuộc tính ngày sửa
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Thuộc tính người sửa
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string ModifiedBy { get; set; }
    }
}