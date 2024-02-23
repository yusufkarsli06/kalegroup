using KaleGroup.Admin.Models;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaleGroup.Admin.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ISettingsLogic _settingsLogic;
        public SettingsController(ISettingsLogic settingsLogic)
        {
            _settingsLogic = settingsLogic;

        }

        public IActionResult Index()
        {
            List<SettingsViewModel> vm = new List<SettingsViewModel>();

            var menuResult = _settingsLogic.GetSettingsList();

            foreach (var item in menuResult)
            {
                SettingsViewModel settings = new SettingsViewModel();
                settings.Id = item.Id;
                settings.SettingsValue = item.SettingsValue;
                settings.SettingsKey = item.SettingsKey;
                settings.IsActive = item.IsActive;

                vm.Add(settings);
            }

            return View(vm);
        }

        public IActionResult AddSetting()
        {
            AddSettingsViewModel vm = new AddSettingsViewModel();
            vm.IsActive = true;
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddSetting(AddSettingsViewModel param)
        {
            SettingsDto settingsDtos = new SettingsDto();

            settingsDtos.Id = param.Id;
            settingsDtos.SettingsValue = param.SettingsValue;
            settingsDtos.SettingsKey = param.SettingsKey.Trim();
            settingsDtos.IsActive = param.IsActive;
            _settingsLogic.AddSettings(settingsDtos);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateSetting(int id)
        {
            AddSettingsViewModel vm = new AddSettingsViewModel();
            var settingsResult = _settingsLogic.GetSettings(id);

            vm.Id = settingsResult.Id;
            vm.SettingsValue = settingsResult.SettingsValue;
            vm.SettingsKey = settingsResult.SettingsKey;
            vm.SettingsKeyHidden = settingsResult.SettingsKey;
            vm.IsActive = settingsResult.IsActive;

            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateSetting(AddSettingsViewModel param)
        {
            SettingsDto settingsDtos = new SettingsDto();
            settingsDtos.Id = param.Id;
            settingsDtos.SettingsValue = param.SettingsValue;
            settingsDtos.SettingsKey = param.SettingsKeyHidden;
            settingsDtos.IsActive = param.IsActive;
            _settingsLogic.UpdateSettings(settingsDtos);
            return RedirectToAction("Index");
        }
      

        public IActionResult DeleteSetting(int id)
        {
            _settingsLogic.DeleteSettings(id);
            return RedirectToAction("Index");
        }
        public IActionResult PasiveSetting(int id)
        {
            _settingsLogic.PasiveSettings(id);
            return RedirectToAction("Index");
        }
    }
}