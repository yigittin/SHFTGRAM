using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.Core.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
