using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DbModels
{
    public class Likes
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
