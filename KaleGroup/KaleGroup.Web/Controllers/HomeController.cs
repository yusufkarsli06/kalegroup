using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KaleGroup.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IMenuLogic _menuLogic;
        //private readonly ISubMenuLogic _subMenuLogic;

        public HomeController(ILogger<HomeController> logger
            //, IMenuLogic menuLogic,ISubMenuLogic subMenuLogic
            )
        {
            _logger = logger;
            //_subMenuLogic = subMenuLogic;
            //_menuLogic = menuLogic; 
        }

        public IActionResult Index()
        {
            List<MenuViewModel> vm = new List<MenuViewModel>();
           // List<SubMenuViewModel> subMenuList = new List<SubMenuViewModel>();


           //var menuResult = _menuLogic.GetMenuList();
           //var subMenuResult = _subMenuLogic.GetSubMenuList();

           // foreach (var item in menuResult)
           // {
           //    MenuViewModel menu = new MenuViewModel();
           //     menu.Name = item.Name;             
           //     menu.EnName= item.EnName;

           //     foreach (var subItem in subMenuResult)
           //     {
           //         SubMenuViewModel subMenu = new SubMenuViewModel();
           //         subMenu.Name= subItem.Name;
           //         subMenu.EnName= subItem.EnName;
           //     }

           //     vm.Add(menu);
           // }

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}