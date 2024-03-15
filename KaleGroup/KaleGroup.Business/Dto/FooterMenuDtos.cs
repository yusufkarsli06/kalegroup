using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Dto
{
    public class FooterMenuDtos : ModelBaseDto
    {
        public string PageName { get; set; }
        public string EnPageName { get; set; }
        public string PageUrl { get; set; }
        public string EnPageUrl { get; set; }
        public string FileUrl { get; set; }
        public string EnFileUrl { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string EnDescription { get; set; }
        public int OrderNumber { get; set; }

    }
}
