using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class UserToken
    {
        public UserData UserData { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
    }
}
