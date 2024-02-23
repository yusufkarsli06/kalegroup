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
        public string EnFilePath { get; set; }
        public bool IsActive { get; set; }
        public int PageId { get; set; }
        public int OrderNumber { get; set; }
        public string PageUrl { get; set; }
        public string EnPageUrl { get; set; }
    }
}
