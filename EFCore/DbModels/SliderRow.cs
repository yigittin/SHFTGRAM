using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class SliderRow:Model
    {
        public int SortNumber { get; set; }
        public int ColumnCount { get; set; }
        public List<Slider> SliderList { get; set; }
    }
}
