using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DbModels
{
    public class UserActionType
    {
        public int UserActionTypeId { get; set; }
        public string Type { get; set; }
        public string ActionName { get; set; }
        public string ActionCategory { get; set; }

    }
}
