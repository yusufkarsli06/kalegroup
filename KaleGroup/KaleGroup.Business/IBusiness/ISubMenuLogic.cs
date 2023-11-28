
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
    public interface ISubMenuLogic
    {
        List<SubMenuDtos> GetSubMenuList();

        void PasiveSubMenu(int subMenuId);
        void DeleteSubMenu(int subMenuId);
        void AddSubMenu(SubMenuDtos param);
        void UpdateSubMenu(SubMenuDtos param);

        SubMenuDtos GetSubMenu(int subMenuId);
    }
}
 
 
 
 
 