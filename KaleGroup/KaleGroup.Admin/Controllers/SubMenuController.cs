using KaleArge.Admin.Filter;
using KaleGroup.Admin.Models;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaleGroup.Web.Controllers
{
    [Authorize]
    [XssProtectionFilter]

    public class SubMenuController : Controller
    {
        private readonly ISubMenuLogic _subMenuLogic;
      
        public SubMenuController(ISubMenuLogic subMenuLogic)
        {
            _subMenuLogic = subMenuLogic;
       
        }

        public IActionResult Index()
        {

            List<SubMenuViewModel> vm = new List<SubMenuViewModel>();


            var subMenuResult = _subMenuLogic.GetSubMenuList();


            foreach (var item in subMenuResult)
            {
                SubMenuViewModel subMenu = new SubMenuViewModel();
                subMenu.Name = item.Name;
                subMenu.EnName = item.EnName;
                subMenu.Description = item.Description;
                subMenu.EnDescription = item.EnDescription;
                subMenu.IsActive = item.IsActive;
                subMenu.Id = item.Id;
                subMenu.IsActive = item.IsActive;


                vm.Add(subMenu);
            }

            return View(vm);

             
        }
        public IActionResult AddSubMenu()
        {
            AddSubMenuViewModel vm = new AddSubMenuViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddSubMenu(AddSubMenuViewModel param)
        {
            SubMenuDtos subMenuDtos = new SubMenuDtos();
            subMenuDtos.Name = param.Name;
            subMenuDtos.EnName = param.EnName;
            subMenuDtos.EnDescription = param.EnDescription;
            subMenuDtos.Description = param.Description;
            subMenuDtos.IsActive = param.IsActive;
            subMenuDtos.MenuId = param.MenuId;

            _subMenuLogic.AddSubMenu(subMenuDtos);
            return RedirectToAction("Index");
        }


        public IActionResult UpdateSubMenu(int subMenuId)
        {
            AddSubMenuViewModel vm = new AddSubMenuViewModel();
            var subMenuDtos = _subMenuLogic.GetSubMenu(subMenuId);

            vm.Name = subMenuDtos.Name;
            vm.EnName = subMenuDtos.EnName;
            vm.EnDescription = subMenuDtos.EnDescription;
            vm.Description = subMenuDtos.Description;
            vm.IsActive = subMenuDtos.IsActive;
            vm.Id = subMenuDtos.Id;
            vm.MenuId = subMenuDtos.MenuId;

            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateSubMenu(AddSubMenuViewModel param)
        {
            SubMenuDtos subMenuDtos = new SubMenuDtos();
            subMenuDtos.Name = param.Name;
            subMenuDtos.EnName = param.EnName;
            subMenuDtos.EnDescription = param.EnDescription;
            subMenuDtos.Description = param.Description;
            subMenuDtos.Id = param.Id;
            subMenuDtos.IsActive = param.IsActive;

            _subMenuLogic.UpdateSubMenu(subMenuDtos);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteSubMenu(int subMenuId)
        {
            _subMenuLogic.DeleteSubMenu(subMenuId);
            return RedirectToAction("Index");
        }
        public IActionResult PasiveSubMenu(int subMenuId)
        {
            _subMenuLogic.PasiveSubMenu(subMenuId);
            return RedirectToAction("Index");
        }
    }
}


 