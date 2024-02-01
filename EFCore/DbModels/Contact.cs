using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class Contact:Model
    {
        public string TelNo { get; set; }
        public string Adress { get; set; }
        public string MapFrame { get; set; }
        public string InfoText { get; set; }
        public List<ContactMails> Mails { get; set; }
    }
}
