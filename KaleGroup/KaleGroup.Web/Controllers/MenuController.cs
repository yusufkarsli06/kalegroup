using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KaleGroup.Web.Controllers
{
    public class MenuController : Controller
    {
     
      
        public MenuController( )
        {
            
       
        }

        public IActionResult Index()
        {
            

            return View();
        }

       
    }
}