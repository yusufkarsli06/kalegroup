using KaleGroup.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Data.Entities
{
    public class Pages : ModelBase
    {
        public string Name { get; set; }
         public int SubMenuId { get; set; }     
        public string PageTopSubject { get; set; }     
        public string PageTopDescription { get; set; }     
        public string PageTopBackground { get; set; }     
        public string PageTopImages { get; set; }     
        public string PageHeader { get; set; }     
        public bool IsSlider { get; set; }     
        public bool IsActive { get; set; }     
        public string PageUrl { get; set; }     
        
    }
}

 
 


























