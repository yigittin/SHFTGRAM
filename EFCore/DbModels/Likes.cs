﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DbModels
{
    [Keyless]
    public class Likes
    {
        public int PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
