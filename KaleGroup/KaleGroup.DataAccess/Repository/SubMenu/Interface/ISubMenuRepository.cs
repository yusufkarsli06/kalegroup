using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KaleGroup.DataAccess.Repository.SubMenu.Interface
{
    public interface ISubMenuRepository:IRepository<SubMenus>
    {
        void UpdateSubMenu(SubMenus subMenu);
        void PasiveSubMenu(int subMenuId);
        List<SubMenus> GetSubMenuList();
        List<SubMenus> GetSubMenuListById(int menuId);
    }
}


