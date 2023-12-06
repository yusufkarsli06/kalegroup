using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KaleGroup.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuLogic _menuLogic;
        private readonly ISubMenuLogic _subMenuLogic;

        public HomeController(ILogger<HomeController> logger,
          IMenuLogic menuLogic,ISubMenuLogic subMenuLogic
            )
        {
            _logger = logger;
            _subMenuLogic = subMenuLogic;
           _menuLogic = menuLogic; 
        }

        public IActionResult Index()
        {
            List<MenuViewModel> vm = new List<MenuViewModel>();
 

            var menuResult = _menuLogic.GetMenuList().Where(x => x.IsActive).ToList();
            var subMenuResult = _subMenuLogic.GetSubMenuList().Where(x=>x.IsActive).ToList();

            foreach (var item in menuResult)
            {
                List<SubMenuViewModel> subMenuList = new List<SubMenuViewModel>();
                MenuViewModel menu = new MenuViewModel();
                menu.Name = item.Name;
                menu.EnName = item.EnName;
                var subMenuListNew = subMenuResult.Where(x => x.MenuId == item.Id).ToList();

                foreach (var subItem in subMenuListNew)
                {
                    SubMenuViewModel subMenu = new SubMenuViewModel();
                    subMenu.Name = subItem.Name;
                    subMenu.EnName = subItem.EnName;
                    subMenu.MenuId = subItem.MenuId;
                    subMenuList.Add(subMenu);
                }
                menu.SubMenuViewModels = subMenuList;
                vm.Add(menu);
            }

            return View(vm);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}