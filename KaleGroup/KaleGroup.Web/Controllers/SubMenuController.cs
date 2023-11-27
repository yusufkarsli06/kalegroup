using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KaleGroup.Web.Controllers
{
    public class SubMenuController : Controller
    {
     
      
        public SubMenuController( )
        {
            
       
        }

        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult AddSubMenu(AddSubMenuViewModel param)
        {
            return View();
        }
        public IActionResult UpdateSubMenu(AddSubMenuViewModel param)
        {
            return View();
        }
        public IActionResult DeleteSubMenu(int subMenuId)
        {
            return View();
        }
        public IActionResult PasiveSubMenu(int subMenuId)
        {
            return View();
        }
    }
}