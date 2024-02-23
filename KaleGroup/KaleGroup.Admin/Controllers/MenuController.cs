using KaleGroup.Admin.Models;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaleGroup.Admin.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuLogic _menuLogic;
        public MenuController(IMenuLogic menuLogic)
        {
            _menuLogic= menuLogic;

        }

        public IActionResult Index()
        {
 
            List<MenuViewModel> vm = new List<MenuViewModel>();
 

            var menuResult = _menuLogic.GetMenuList();
           

            foreach (var item in menuResult)
            {
                MenuViewModel menu = new MenuViewModel();
                menu.Name = item.Name;
                menu.EnName = item.EnName;
                menu.Description = item.Description;
                menu.EnDescription = item.EnDescription;
                menu.IsActive = item.IsActive;
                menu.Id= item.Id;
                 
            
                vm.Add(menu);
            }

            return View(vm);
 
        }

        public IActionResult AddMenu()
        {
            AddMenuViewModel vm = new AddMenuViewModel();
            vm.IsActive = true;
            return View(vm);
        }
        public IActionResult UpdateMenu(int menuId)
        {
            AddMenuViewModel vm = new AddMenuViewModel();
           var menuDtos= _menuLogic.GetMenu(menuId);
           
            vm.Name = menuDtos.Name;
            vm.EnName = menuDtos.EnName;
            vm.EnDescription = menuDtos.EnDescription;
            vm.Description = menuDtos.Description;
            vm.IsActive = menuDtos.IsActive;
            vm.Id = menuDtos.Id;
             

            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateMenu(AddMenuViewModel param)
        {
            MenuDtos menuDtos = new MenuDtos();
            menuDtos.Name = param.Name;
            menuDtos.EnName = param.EnName;
            menuDtos.EnDescription = param.EnDescription;
            menuDtos.Description = param.Description;
            menuDtos.Id = param.Id;
            menuDtos.IsActive = param.IsActive;

            _menuLogic.UpdateMenu(menuDtos);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddMenu(AddMenuViewModel param)
        {
            MenuDtos menuDtos = new MenuDtos();
            menuDtos.Name = param.Name;
            menuDtos.EnName = param.EnName;
            menuDtos.EnDescription = param.EnDescription;
            menuDtos.Description = param.Description;
            menuDtos.IsActive = param.IsActive;
            _menuLogic.AddMenu(menuDtos);
            return RedirectToAction("Index");
        }

      
        public IActionResult DeleteMenu(int menuId)
        {
            _menuLogic.DeleteMenu(menuId);
            return RedirectToAction("Index");
        }
        public IActionResult PasiveMenu(int menuId)
        {
            _menuLogic.PasiveMenu(menuId);
            return RedirectToAction("Index");
        }
    }
}