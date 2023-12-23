using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Dto
{
    public class SliderDtos : ModelBaseDto
    {
        public string FilePath { get; set; }
        public bool IsActive { get; set; }
        public int MenuId { get; set; }
        public int OrderNumber { get; set; }

    }
}
