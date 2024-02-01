using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string param)
        {
            Message = param + " Not Found";
        }

        public string Message { get; set; }
    }
}

