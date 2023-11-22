using KaleGroup.Data.Entities;


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.SubMenu.Interface
{
    public interface ISubMenuRepository
    {
        bool AddSubMenu(SubMenu subMenu);
        List<SubMenu> GetSubMenuList(int subMenuId);
        bool UpdateSubMenu(SubMenu subMenu);
        bool DeleteSubMenu(int subMenuId);

    }
}
