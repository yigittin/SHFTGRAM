using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DbModels
{
    public class RoleActionType
    {
        public int RoleActionTypeId { get; set; }
        public Guid RoleTypeId { get; set; }

        [ForeignKey("RoleTypeId")]
        public RoleType RoleType { get; set; }

        [ForeignKey("UserActionTypeId")]
        public UserActionType UserActionType { get; set; }
        public int UserActionTypeId { get; set; }
    }
}
