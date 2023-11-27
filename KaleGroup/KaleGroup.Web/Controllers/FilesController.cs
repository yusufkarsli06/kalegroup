using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KaleGroup.Web.Controllers
{
    public class FilesController : Controller
    {
     
      
        public FilesController( )
        {
            
       
        }

        public IActionResult Index()
        {
             
            return View();
        }
        public IActionResult AddFile(AddFileViewModel param)
        { 

            return View();
        }

        public IActionResult UpdateFile(AddFileViewModel param)
        {
             
            return View();
        }
        public IActionResult DeleteFile()
        {


            return View();
        }
    }
}