using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Common.Helper;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using KaleGroup.DataAccess.Repository.User.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Business
{
    public class MenuLogic : IMenuLogic
    {
        private readonly IMenuRepository _menuRepository;

        public MenuLogic(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public List<MenuDtos> GetMenuDtos()
        {
            List<MenuDtos> menuList = new List<MenuDtos>();
            var menuResult = _menuRepository.GetMenuList();
            foreach ( var item in menuResult)
            {
                MenuDtos menu = new MenuDtos();
                menu.Name= item.Name;
                menu.Description= item.Description;
                menu.EnDescription= item.EnDescription;
                menu.EnName= item.EnName;
                menu.Id= item.Id;
                menuList.Add(menu); 

            }
            return menuList;
        }
    }
}


 
 