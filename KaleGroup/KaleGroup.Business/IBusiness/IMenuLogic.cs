
using KaleGroup.Business.Dto;
using KaleGroup.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.IBusiness
{
    public interface IMenuLogic
    {
       List<MenuDtos> GetMenuList();
        void PasiveMenu(int menuId);
        void DeleteMenu(int menuId);
        void AddMenu(MenuDtos param);
        MenuDtos GetMenu(int menuId);
        void UpdateMenu(MenuDtos param);
    }
}
