using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DbModels
{
    public class RoleType
    {
        public Guid RoleTypeId { get; set; }
        public string RoleName { get; set; }
        public string RoleNameLowered { get; set; }
        public bool IsListed { get; set; }
    }
}
