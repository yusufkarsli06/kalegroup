using KaleGroup.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Data.Entities
{
    public class Slider : ModelBase
    {
        public string FilePath { get; set; }
        public string PageUrl { get; set; }
        public string EnPageUrl { get; set; }
        public bool IsActive { get; set; }
        public int MenuId { get; set; }
        public int OrderNumber { get; set; }

    }
}





