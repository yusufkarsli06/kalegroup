using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KaleGroup.Web.Controllers
{
    public class UserController : Controller
    {  
      
        public UserController( )
        {         
            
        } 

     
        public IActionResult Logout()
        {

            return View();
        }
        public IActionResult AddUser(AddUserViewModel param)
        {

            return View();
        }

        public IActionResult PasiveUser(int userId)
        {

            return View();
        }
    }
}