using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Dto
{
   
    public class SettingsDto : ModelBaseDto
    {
        public string SettingsKey { get; set; }
        public string SettingsValue { get; set; }
        public bool IsActive { get; set; }     

    }
}
