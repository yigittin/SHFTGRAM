using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.Core.Exceptions
{
    public class NotAuth:Exception
    {
        public NotAuth() : base()
        {
            Message = "Unauthorized";
        }

        public string Message { get; set; }
    }
}
