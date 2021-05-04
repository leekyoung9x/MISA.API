using MISA.Core.AttributeCustom;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    // TODO: Thêm các attribute validate
    public class CustomerGroup : BaseEntity
    {
        public Guid CustomerGroupId { get; set; }

        [CDisplayName("Nhóm khách hàng")]
        [CRequired]
        [CMaxLength(maxLength: 5)]
        public string CustomerGroupName { get; set; }

        [CDisplayName("Mô tả nhóm khách hàng")]
        [CRequired]
        public string Description { get; set; }

        public string ParentId { get; set; }
    }
}