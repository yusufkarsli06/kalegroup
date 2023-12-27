using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Common.Helper;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.Settings.Interface;

namespace KaleGroup.Business.Business
{
    public class SettingsLogic:ISettingsLogic
    {
        private readonly ISettingsRepository _settingsRepository;
        private readonly ICacheHelper _cacheHelper;
        string settingsCacheKey="kalearge-settings-cache";
        public SettingsLogic(ISettingsRepository settingsRepository, ICacheHelper cacheHelper)
        {
            _settingsRepository = settingsRepository;
            _cacheHelper = cacheHelper;
        }
        public List<SettingsDto> GetSettingsList()
        {
            List<SettingsDto> settingsList = new List<SettingsDto>();
            var settingsResult = _settingsRepository.Table.Where(x =>   x.IsActive);
            foreach (var item in settingsResult)
            {
                SettingsDto settings = new SettingsDto();

                settings.SettingsKey = item.SettingsKey;
                settings.SettingsValue = item.SettingsValue;
                settings.IsActive = item.IsActive;
                settings.Id = item.Id;
             
                settingsList.Add(settings);

            }
            //todo cache nasıl set edilecek.
          //  _cacheHelper.SetCache(settingsCacheKey, settingsList);

            return settingsList;
        }
        public void PasiveSettings(int id)
        {
            _settingsRepository.PasiveSettings(id);

        }
        public void DeleteSettings(int id)
        {
            _settingsRepository.Delete(id);
            _cacheHelper.DeleteCache(settingsCacheKey);
        }

        public void AddSettings(SettingsDto param)
        {
            Settings settings = new Settings();

            settings.SettingsKey = param.SettingsKey;
            settings.SettingsValue = param.SettingsValue;
            settings.IsActive = true;

            _settingsRepository.Insert(settings);
            
            _cacheHelper.DeleteCache(settingsCacheKey);
        }
        public void UpdateSettings(SettingsDto param)
        {
            Settings settings = new Settings();

            settings.SettingsKey = param.SettingsKey;
            settings.SettingsValue = param.SettingsValue;
            settings.IsActive = param.IsActive;

            _settingsRepository.Update(settings);
            _cacheHelper.DeleteCache(settingsCacheKey);
        }

        public SettingsDto GetSettings(int id)
        {
            SettingsDto settingsDto = new SettingsDto();

            var settingsResult = _settingsRepository.GetById(id);

            settingsDto.SettingsKey = settingsResult.SettingsKey;
            settingsDto.SettingsValue = settingsResult.SettingsValue;
            settingsDto.IsActive = settingsResult.IsActive; 
            return settingsDto;
        }

    }
}
 
  
  

 
 