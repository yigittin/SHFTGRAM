using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class ContactMails:ModelNoLang
    {
        public string MailName { get; set; }
        public string Mail { get; set; }
        [ForeignKey("ContactId")]
        public Contact Contact{ get; set; }
        public int ContactId { get; set; }
    }
}
