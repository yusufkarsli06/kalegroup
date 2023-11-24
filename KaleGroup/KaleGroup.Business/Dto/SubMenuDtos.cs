using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Dto
{
    public class SubMenuDtos : ModelBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MenuId { get; set; }
        public bool IsActive { get; set; }
    }
}
