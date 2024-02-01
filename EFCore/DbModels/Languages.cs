using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class Languages : ModelNoLang
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string LanguageCode { get; set; }
        public string FlagPic { get; set; }
    }
}
