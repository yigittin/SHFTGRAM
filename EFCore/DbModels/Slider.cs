using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class Slider : ModelNoLang
    {
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public string ProductName { get; set; }
        public string MobileImagePath { get; set; }
        public string? VideoPath { get; set; }
        public string? MobileVideoPath { get; set; }
        public bool IsVideo { get; set; }
        public string BackgroundImage{ get; set; }
        public string MobileBackgroundImage { get; set; }
        public int SortNumber { get; set; }
        [ForeignKey("RowId")]
        public SliderRow Row{ get; set; }
        public int RowId { get; set; }
    }
}
