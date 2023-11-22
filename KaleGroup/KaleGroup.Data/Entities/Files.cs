﻿using KaleGroup.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Data.Entities
{
    public class Files : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; }     
        public string NewsImages { get; set; }     
        public string TopHeaderImages { get; set; }     
        public string TopHeaderBackground { get; set; }     
        
    }
}

 



 











