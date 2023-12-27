using KaleGroup.Business.Dto;
using KaleGroup.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.IBusiness
{
    public interface ISettingsLogic
    {
        List<SettingsDto> GetSettingsList();
        void PasiveSettings(int id);
        void DeleteSettings(int id);
        void AddSettings(SettingsDto param);
        void UpdateSettings(SettingsDto param);
        SettingsDto GetSettings(int id);

    }
}
