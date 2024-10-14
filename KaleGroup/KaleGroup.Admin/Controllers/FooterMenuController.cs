using KaleArge.Admin.Filter;
using KaleGroup.Admin.Models;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaleGroup.Admin.Controllers
{
    [Authorize]
    [XssProtectionFilter]
    public class FooterMenuController : Controller
    {
        private readonly IFooterMenusLogic _footerMenusLogic;
        public FooterMenuController(IFooterMenusLogic footerMenusLogic)
        {
            _footerMenusLogic = footerMenusLogic;

        }

        public IActionResult Index()
        {
            List<FooterMenuViewModel> vm = new List<FooterMenuViewModel>();

            var footerMenuResult = _footerMenusLogic.GetFooterMenuList();

            foreach (var item in footerMenuResult)
            {
                FooterMenuViewModel footerMenu = new FooterMenuViewModel();

                footerMenu.PageName = item.PageName;
                footerMenu.IsActive = item.IsActive;
                footerMenu.Id = item.Id;
                footerMenu.OrderNumber = item.OrderNumber;
                footerMenu.PageTopSubject = item.PageTopSubject;
                vm.Add(footerMenu);
            }

            return View(vm);

        }

        public IActionResult AddFooterMenu()
        {
            AddFooterMenuViewModel vm = new AddFooterMenuViewModel();
            vm.IsActive = true;
            return View(vm);
        }
        public IActionResult UpdateFooterMenu(int footerMenuId)
        {
            AddFooterMenuViewModel vm = new AddFooterMenuViewModel();

            var footerMenuDtos = _footerMenusLogic.GetFooterMenu(footerMenuId);

            vm.Id = footerMenuDtos.Id;
            vm.PageName = footerMenuDtos.PageName;
            vm.EnPageName = footerMenuDtos.EnPageName;
            vm.PageUrl = footerMenuDtos.PageUrl;
            vm.EnPageUrl = footerMenuDtos.EnPageUrl;
            vm.FileUrl = footerMenuDtos.FileUrl;
            vm.EnFileUrl = footerMenuDtos.EnFileUrl;
            vm.IsActive = footerMenuDtos.IsActive;
            vm.Description = footerMenuDtos.Description;
            vm.EnDescription = footerMenuDtos.EnDescription;
            vm.OrderNumber = footerMenuDtos.OrderNumber;
            vm.PageTopBackground = footerMenuDtos.PageTopBackground;
            vm.PageTopSubject = footerMenuDtos.PageTopSubject;
            vm.PageTopDescription = footerMenuDtos.PageTopDescription;
            vm.EnPageTopSubject = footerMenuDtos.EnPageTopSubject;
            vm.EnPageTopDescription = footerMenuDtos.EnPageTopDescription;
            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateFooterMenu(AddFooterMenuViewModel param)
        {
            FooterMenuDtos footerMenuDtos = new FooterMenuDtos();

            if (param.UploadFile != null)
            {
                var extent = Path.GetExtension(param.UploadFile.FileName);

                string randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(@"../kalearge.canavardata.com/wwwroot/Uploads", randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.UploadFile.CopyTo(fileStream);
                footerMenuDtos.FileUrl = "Uploads/" + randomName;
            }
            else
            {
                footerMenuDtos.FileUrl = param.FileUrl;
            }

            if (param.EnUploadFile != null)
            {
                var extent = Path.GetExtension(param.EnUploadFile.FileName);

                string randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(@"../kalearge.canavardata.com/wwwroot/Uploads", randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.EnUploadFile.CopyTo(fileStream);

                footerMenuDtos.EnFileUrl = "Uploads/" + randomName;
            }
            else
            {
                footerMenuDtos.EnFileUrl = param.EnFileUrl;
            }

            footerMenuDtos.Id = param.Id;
            footerMenuDtos.PageName = param.PageName;
            footerMenuDtos.EnPageName = param.EnPageName;
            footerMenuDtos.PageUrl = param.PageUrl;
            footerMenuDtos.EnPageUrl = param.EnPageUrl;
            footerMenuDtos.IsActive = param.IsActive;
            footerMenuDtos.Description = param.Description;
            footerMenuDtos.EnDescription = param.EnDescription;
            footerMenuDtos.OrderNumber = param.OrderNumber;
            footerMenuDtos.PageTopSubject = param.PageTopSubject;
            footerMenuDtos.PageTopBackground = param.PageTopBackground;
            footerMenuDtos.PageTopDescription = param.PageTopDescription;
            footerMenuDtos.EnPageTopSubject = param.EnPageTopSubject;
            footerMenuDtos.EnPageTopDescription = param.EnPageTopDescription;
            _footerMenusLogic.UpdateFooterMenu(footerMenuDtos);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddFooterMenu(AddFooterMenuViewModel param)
        {
            FooterMenuDtos footerMenuDtos = new FooterMenuDtos();

            if (param.UploadFile != null)
            {
                var extent = Path.GetExtension(param.UploadFile.FileName);

                string randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(@"../kalearge.canavardata.com/wwwroot/Uploads", randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.UploadFile.CopyTo(fileStream);
                footerMenuDtos.FileUrl = "Uploads/" + randomName;
            }
            else
            {
                footerMenuDtos.FileUrl = null;
            }

            if (param.EnUploadFile != null)
            {
                var extent = Path.GetExtension(param.EnUploadFile.FileName);

                string randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(@"../kalearge.canavardata.com/wwwroot/Uploads", randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.EnUploadFile.CopyTo(fileStream);

                footerMenuDtos.EnFileUrl = "Uploads/" + randomName;
            }
            else
            {
                footerMenuDtos.EnFileUrl = null;
            }

            footerMenuDtos.PageName = param.PageName;
            footerMenuDtos.EnPageName = param.EnPageName;
            footerMenuDtos.PageUrl = param.PageUrl;
            footerMenuDtos.EnPageUrl = param.EnPageUrl;
            footerMenuDtos.IsActive = param.IsActive;
            footerMenuDtos.Description = param.Description;
            footerMenuDtos.EnDescription = param.EnDescription;
            footerMenuDtos.OrderNumber = param.OrderNumber;
            footerMenuDtos.PageTopSubject = param.PageTopSubject;
            footerMenuDtos.PageTopBackground = param.PageTopBackground;
            footerMenuDtos.PageTopDescription = param.PageTopDescription;

            footerMenuDtos.EnPageTopSubject = param.EnPageTopSubject;
            footerMenuDtos.EnPageTopDescription = param.EnPageTopDescription;
            _footerMenusLogic.AddFooterMenu(footerMenuDtos);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFooterMenu(int footerMenuId)
        {
            _footerMenusLogic.DeleteFooterMenu(footerMenuId);
            return RedirectToAction("Index");
        }
        public IActionResult PasiveFooterMenu(int footerMenuId)
        {
            _footerMenusLogic.PasiveFooterMenu(footerMenuId);
            return RedirectToAction("Index");
        }
    }
}