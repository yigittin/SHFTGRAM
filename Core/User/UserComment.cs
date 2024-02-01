using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.Core.User
{
    public class UserComment
    {
        public Guid? Id { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid CommenterId { get; set; }
        public int Point { get; set; }
    }
}
