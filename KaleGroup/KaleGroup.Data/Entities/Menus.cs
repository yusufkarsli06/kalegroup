﻿using KaleGroup.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Data.Entities
{
    public class Menus:ModelBase
    {
        public string Name  { get; set; }
        public string Description  { get; set; }
        public bool IsActive { get; set; }
        public string EnName { get; set; }
        public string EnDescription { get; set; }
        public int OrderNumber { get; set; }
    }
}

