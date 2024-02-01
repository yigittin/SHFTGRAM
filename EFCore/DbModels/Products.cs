using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class Product:ModelNoLang
    {
        public string UrlTag { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string MobileImagePath { get; set; }
        public string Text { get; set; }
        public string HomeText { get; set; }
        public string? YoutubeLink { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
