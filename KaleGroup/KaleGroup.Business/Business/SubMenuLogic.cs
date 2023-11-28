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
    public class SubMenuLogic : ISubMenuLogic
    {
        private readonly ISubMenuRepository _subMenuRepository;

        public SubMenuLogic(ISubMenuRepository subMenuRepository)
        {
            _subMenuRepository = subMenuRepository;
        }

        public List<SubMenuDtos> GetSubMenuList()
        {
            List<SubMenuDtos> subMenuList = new List<SubMenuDtos>();
            var subMenuResult = _subMenuRepository.GetSubMenuList();
            foreach ( var item in subMenuResult)
            {
                SubMenuDtos menu = new SubMenuDtos();
                menu.Name= item.Name;
                menu.Description= item.Description;
                menu.EnDescription= item.EnDescription;
                menu.EnName= item.EnName;
                menu.Id= item.Id;
                menu.MenuId= item.MenuId;
                subMenuList.Add(menu); 

            }
            return subMenuList;
        }
    }
}


 
 