using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class AboutUs
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public int Language { get; set; }

    }
}
