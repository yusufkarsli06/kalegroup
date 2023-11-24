using KaleGroup.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Data.Entities
{
    public class SubMenus : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MenuId { get; set; }
        public bool IsActive { get; set; }
    }
}
 