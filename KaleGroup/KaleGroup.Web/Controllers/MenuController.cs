using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KaleGroup.Web.Controllers
{
    public class MenuController : Controller
    {

        public MenuController()
        {


        }

        public IActionResult Index()
        {
            List<AddMenuViewModel> vm = new List<AddMenuViewModel>();



            return View(vm);
        }

        public IActionResult AddMenu(AddMenuViewModel param)
        {
            return View();
        }
        public IActionResult UpdateMenu(AddMenuViewModel param)
        {
            return View();
        }
        public IActionResult DeleteMenu(int menuId)
        {
            return View();
        }
        public IActionResult PasiveMenu(int menuId)
        {
            return View();
        }
    }
}