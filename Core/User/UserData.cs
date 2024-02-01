using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class UserData
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
