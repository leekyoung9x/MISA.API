using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class CustomerGroup : BaseEntity
    {
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
        public string ParentId { get; set; }
    }
}