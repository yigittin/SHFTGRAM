using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DbModels
{
    public class LayoutLink
    {
        public int LayoutLinkId { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public string LinkIcon { get; set; }
        public int UpperId { get; set; }
        public int LinkOrder { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public int? ActionId { get; set; }
    }
}
