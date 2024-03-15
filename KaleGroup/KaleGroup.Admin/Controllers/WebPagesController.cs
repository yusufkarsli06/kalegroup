using KaleGroup.Admin.Models;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KaleGroup.Admin.Controllers
{
    [Authorize]
    public class WebPagesController : Controller
    {

        private readonly IWebPagesLogic _webPagesLogic;
        private readonly IMenuLogic _menuLogic;
        public WebPagesController(IWebPagesLogic webPagesLogic, IMenuLogic menuLogic)
        {
            _webPagesLogic = webPagesLogic;
            _menuLogic = menuLogic;

        }
        public IActionResult Index()
        {
            List<WebPagesViewModel> vm = new List<WebPagesViewModel>();


            var pagesResult = _webPagesLogic.GetAllWebPagesList();


            foreach (var item in pagesResult)
            {
                WebPagesViewModel pages = new WebPagesViewModel();

                pages.Id = item.Id;
                pages.Name = item.Name;
                pages.PageUrl = item.PageUrl;
                pages.IsActive = item.IsActive;
                pages.CreatedAt = item.CreatedAt.ToString("dd.MM.yyyy");
                vm.Add(pages);
            }

            return View(vm);

        }

        public IActionResult AddPage()
        {
            AddWebPagesViewModel vm = new AddWebPagesViewModel();

            List<MenuSelectionViewModel> menuList = new List<MenuSelectionViewModel>();
            var menuListResult = _menuLogic.GetMenuList().Where(x => x.IsActive);

            foreach (var item in menuListResult)
            {
                MenuSelectionViewModel menu = new MenuSelectionViewModel();

                menu.MenuName = item.Name;
                menu.MenuId = item.Id;
                menuList.Add(menu);

            }
            vm.MenuSelectionViewModel = menuList;
            vm.IsActive = true;
            return View(vm);

        }

        [HttpPost]
        public IActionResult AddPage(AddWebPagesViewModel param)
        {
 
            WebPagesDtos pagesDto = new WebPagesDtos();

            if (param.UploadFile != null)
            {
                var extent = Path.GetExtension(param.UploadFile.FileName);

               string  randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(@"../kalearge.canavardata.com/wwwroot/Uploads", randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.UploadFile.CopyTo(fileStream);
                pagesDto.PageTopImages = "Uploads/" + randomName;
            }
            else
            {
                pagesDto.PageTopImages = null;
            } 
            
            if (param.HomeImageUploadFile != null)
            {
                var extent = Path.GetExtension(param.HomeImageUploadFile.FileName);

               string  randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(@"../kalearge.canavardata.com/wwwroot/Uploads", randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.HomeImageUploadFile.CopyTo(fileStream);
                pagesDto.HomeImage = "Uploads/" + randomName;
            }
            else
            {
                pagesDto.HomeImage = null;
            }



            pagesDto.Name = param.Name;
            pagesDto.MenuId = param.MenuId;
            pagesDto.PageTopSubject = param.PageTopSubject;
            pagesDto.PageTopDescription = param.PageTopDescription;
            pagesDto.PageTopBackground = param.PageTopBackground;
         
            pagesDto.PageDescription = param.PageDescription;
            pagesDto.IsActive = param.IsActive;
            pagesDto.PageUrl = param.PageUrl;
            pagesDto.Keyword = param.Keyword;
            pagesDto.EnName = param.EnName;
            pagesDto.EnPageTopSubject = param.EnPageTopSubject;
            pagesDto.EnPageTopDescription = param.EnPageTopDescription;
            pagesDto.EnPageTopBackground = param.EnPageTopBackground;
            pagesDto.EnPageDescription = param.EnPageDescription;
            pagesDto.EnPageUrl = param.EnPageUrl;
            pagesDto.IsNews = param.IsNews;
            pagesDto.IsSubMenu = param.IsSubMenu;
            pagesDto.IsMenu = param.IsMenu;
            pagesDto.IsTopBody = param.IsTopBody;
            pagesDto.IsButtomBody = param.IsButtomBody;
            pagesDto.CreatedAt = DateTime.Now;
            pagesDto.EnKeyword = param.EnKeyword;
            pagesDto.IsSlider = param.IsSlider;
     


            _webPagesLogic.AddWebPages(pagesDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePage(int id)
        {
            _webPagesLogic.DeletePage(id);
            return RedirectToAction("Index");
        }

        public IActionResult PasivePage(int id)
        {
            _webPagesLogic.PasivePage(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePage(int id)
        {
            AddWebPagesViewModel vm = new AddWebPagesViewModel();


            List<MenuSelectionViewModel> menuList = new List<MenuSelectionViewModel>();
            var menuListResult = _menuLogic.GetMenuList().Where(x => x.IsActive);

            foreach (var item in menuListResult)
            {
                MenuSelectionViewModel menu = new MenuSelectionViewModel();

                menu.MenuName = item.Name;
                menu.MenuId = item.Id;
                menuList.Add(menu);

            }
            vm.MenuSelectionViewModel = menuList;

            var pagesResult = _webPagesLogic.GetWebPageById(id);

            vm.Id = pagesResult.Id;
            vm.Name = pagesResult.Name;
            vm.MenuId = pagesResult.MenuId;
            vm.PageTopSubject = pagesResult.PageTopSubject;
            vm.PageTopDescription = pagesResult.PageTopDescription;
            vm.PageTopBackground = pagesResult.PageTopBackground;
           
            vm.PageDescription = pagesResult.PageDescription;
            vm.IsActive = pagesResult.IsActive;
            vm.PageUrl = pagesResult.PageUrl;
            vm.Keyword = pagesResult.Keyword;
            vm.EnName = pagesResult.EnName;
            vm.EnPageTopSubject = pagesResult.EnPageTopSubject;
            vm.EnPageTopDescription = pagesResult.EnPageTopDescription;
            vm.EnPageTopBackground = pagesResult.EnPageTopBackground;
            vm.EnPageDescription = pagesResult.EnPageDescription;
            vm.EnPageUrl = pagesResult.EnPageUrl;
            vm.IsNews = pagesResult.IsNews;
            vm.IsSubMenu = pagesResult.IsSubMenu;
            vm.IsMenu = pagesResult.IsMenu;
            vm.IsTopBody = pagesResult.IsTopBody;
            vm.IsButtomBody = pagesResult.IsButtomBody;
            vm.EnKeyword = pagesResult.EnKeyword;
            vm.IsSlider = pagesResult.IsSlider;
            vm.PageTopImages = pagesResult.PageTopImages;
            vm.HomeImage = pagesResult.HomeImage;


     

            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdatePage(AddWebPagesViewModel param)
        {
            WebPagesDtos pageDtos = new WebPagesDtos();
            pageDtos.Id = param.Id;
            pageDtos.Name = param.Name;
            pageDtos.MenuId = param.MenuId;
            pageDtos.PageTopSubject = param.PageTopSubject;
            pageDtos.PageTopDescription = param.PageTopDescription;
            pageDtos.PageTopBackground = param.PageTopBackground;
            pageDtos.PageTopImages = param.PageTopImages;
            pageDtos.PageDescription = param.PageDescription;
            pageDtos.IsActive = param.IsActive;
            pageDtos.PageUrl = param.PageUrl;
            pageDtos.Keyword = param.Keyword;
            pageDtos.EnName = param.EnName;
            pageDtos.EnPageTopSubject = param.EnPageTopSubject;
            pageDtos.EnPageTopDescription = param.EnPageTopDescription;
            pageDtos.EnPageTopBackground = param.EnPageTopBackground;
            pageDtos.EnPageDescription = param.EnPageDescription;
            pageDtos.EnPageUrl = param.EnPageUrl;
            pageDtos.IsNews = param.IsNews;
            pageDtos.IsSubMenu = param.IsSubMenu;
            pageDtos.IsMenu = param.IsMenu;
            pageDtos.IsTopBody = param.IsTopBody;
            pageDtos.IsButtomBody = param.IsButtomBody;
            pageDtos.EnKeyword = param.EnKeyword;
            pageDtos.IsSlider = param.IsSlider;

            if (param.UploadFile != null)
            {
                var extent = Path.GetExtension(param.UploadFile.FileName);

                string randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(@"../kalearge.canavardata.com/wwwroot/Uploads", randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.UploadFile.CopyTo(fileStream);
                pageDtos.PageTopImages = "Uploads/" + randomName;
            }
            else
            {
                pageDtos.PageTopImages = param.PageTopImages;
            }

            if (param.HomeImageUploadFile != null)
            {
                var extent = Path.GetExtension(param.HomeImageUploadFile.FileName);

                string randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(@"../kalearge.canavardata.com/wwwroot/Uploads", randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.HomeImageUploadFile.CopyTo(fileStream);
                pageDtos.HomeImage = "Uploads/" + randomName;
            }
            else
            {
                pageDtos.HomeImage = param.HomeImage;
            }

            _webPagesLogic.UpdateWebPages(pageDtos);

            return RedirectToAction("Index");
        }
    }
}