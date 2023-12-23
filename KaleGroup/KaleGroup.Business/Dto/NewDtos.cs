using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Dto
{
    public class NewDtos : ModelBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PageUrl { get; set; }
        public string EnName { get; set; }
        public string EnDescription { get; set; }
        public string FilePath { get; set; }
    }
}
