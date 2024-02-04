using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DbModels
{
    public class Follow
    {
        public int Id { get; set; }
        public Guid FollowerId { get; set; }
        public string FollowerUserName{ get; set; }
        public Guid FollowingId { get; set; }
        public string FollowingUserName { get; set; }
    }
}
