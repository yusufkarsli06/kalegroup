using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;

namespace KaleGroup.Business.Business
{
    public class MenuLogic : IMenuLogic
    {
        private readonly IMenuRepository _menuRepository;

        public MenuLogic(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public List<MenuDtos> GetMenuList()
        {
            List<MenuDtos> menuList = new List<MenuDtos>();
            var menuResult = _menuRepository.GetAll();
            foreach (var item in menuResult)
            {
                MenuDtos menu = new MenuDtos();
                menu.Name = item.Name;
                menu.Description = item.Description;
                menu.EnDescription = item.EnDescription;
                menu.EnName = item.EnName;
                menu.IsActive = item.IsActive;
                menu.Id = item.Id;
                menuList.Add(menu);

            }
            return menuList;
        }
        public void PasiveMenu(int menuId)
        {
            _menuRepository.PasiveMenu(menuId);
        }

        public void DeleteMenu(int menuId)
        {
            _menuRepository.Delete(menuId);
        }
        public void AddMenu(MenuDtos param)
        {
            Menus menus = new Menus();
            menus.Name = param.Name;
            menus.Description = param.Description;
            menus.EnDescription = param.EnDescription;
            menus.EnName = param.EnName;
            menus.IsActive = true;
            _menuRepository.Insert(menus);
        }

        public void UpdateMenu(MenuDtos param)
        {
            Menus menus = new Menus();
            menus.Id = param.Id;
            menus.Name = param.Name;
            menus.Description = param.Description;
            menus.EnDescription = param.EnDescription;
            menus.EnName = param.EnName;
            menus.IsActive = true;
            _menuRepository.Update(menus);
        }

        public MenuDtos GetMenu(int menuId)
        {
            MenuDtos menuDtos = new MenuDtos();

            var menuResult = _menuRepository.GetById(menuId);

            menuDtos.EnDescription  = menuResult.EnDescription;
            menuDtos.Description = menuResult.Description;  
            menuDtos.Name = menuResult.Name;
            menuDtos.EnName = menuResult.EnName;
            menuDtos.IsActive = menuResult.IsActive;
            menuDtos.Id = menuResult.Id;
            return menuDtos;


        }
    }
}



