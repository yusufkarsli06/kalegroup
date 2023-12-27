using KaleGroup.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Data.Entities
{
    public class Settings : ModelBase
    {
        public string SettingsKey { get; set; }
        public string SettingsValue { get; set; }
        public bool IsActive { get; set; }


    }
}





