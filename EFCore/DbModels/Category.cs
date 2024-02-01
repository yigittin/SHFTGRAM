﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.EFCore.DbModels
{
    public class Category:Model
    {
        public string UrlTag { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public int UpperCategoryId { get; set; }
    }
}
