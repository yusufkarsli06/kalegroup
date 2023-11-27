using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KaleGroup.Web.Controllers
{
    public class AdminController : Controller
    {
     
      
        public AdminController( )
        {
            
       
        }

        public IActionResult Index()
        {
            

            return View();
        }
        public IActionResult Login(LoginViewModel param)
        {


            return View();
        }

    }
}