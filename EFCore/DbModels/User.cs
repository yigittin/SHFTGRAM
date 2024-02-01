using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DbModels
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsLocked { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastActivateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastPasswordResetDate { get; set; }
        public int WrongPasswordCount { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        [ForeignKey("RoleId")]
        public RoleType RoleType { get; set; }
        public Guid RoleId { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ConfirmationGuid { get; set; }
        public double PointAverage { get; set; }
        public int PointCount { get; set; }
        public long TotalPoint { get; set; }

    }
}
