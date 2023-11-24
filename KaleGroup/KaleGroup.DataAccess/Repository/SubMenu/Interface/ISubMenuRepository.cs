using KaleGroup.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KaleGroup.DataAccess.Repository.SubMenu.Interface
{
    public interface ISubMenuRepository
    {
        bool AddSubMenu(SubMenus subMenu);
        bool UpdateSubMenu(SubMenus subMenu);
        bool PasiveSubMenu(int subMenuId);
        List<SubMenus> GetSubMenuList(int subMenuId);
    }
}

 
 