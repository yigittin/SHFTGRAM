using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class UploadedFiles:ModelNoLang
    {
        public string OldFileName { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string FileExtention { get; set; }
    }
}
