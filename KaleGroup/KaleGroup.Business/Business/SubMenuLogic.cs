using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;

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
            foreach (var item in subMenuResult)
            {
                SubMenuDtos subMenu = new SubMenuDtos();
                subMenu.Name = item.Name;
                subMenu.Description = item.Description;
                subMenu.EnDescription = item.EnDescription;
                subMenu.EnName = item.EnName;
                subMenu.IsActive = item.IsActive;
                subMenu.Id = item.Id;
                subMenu.MenuId = item.MenuId;
                subMenuList.Add(subMenu);

            }
            return subMenuList;
        }
        public void PasiveSubMenu(int subMenuId)
        {
            _subMenuRepository.PasiveSubMenu(subMenuId);
        }

        public void DeleteSubMenu(int subMenuId)
        {
            _subMenuRepository.Delete(subMenuId);
        }
        public void AddSubMenu(SubMenuDtos param)
        {
            SubMenus subMenus = new SubMenus();
            subMenus.Name = param.Name;
            subMenus.Description = param.Description;
            subMenus.EnDescription = param.EnDescription;
            subMenus.EnName = param.EnName;
            subMenus.IsActive = true;
            subMenus.MenuId = param.MenuId;
            _subMenuRepository.Insert(subMenus);
        }

        public void UpdateSubMenu(SubMenuDtos param)
        {
            SubMenus subMenus = new SubMenus();
            subMenus.Name = param.Name;
            subMenus.Description = param.Description;
            subMenus.EnDescription = param.EnDescription;
            subMenus.EnName = param.EnName;
            subMenus.IsActive = true;
            subMenus.MenuId = param.MenuId;
            _subMenuRepository.Update(subMenus);
        }

        public SubMenuDtos GetSubMenu(int subMenuId)
        {
            SubMenuDtos subMenuDtos = new SubMenuDtos();

            var subMenuResult = _subMenuRepository.GetById(subMenuId);

            subMenuDtos.EnDescription = subMenuResult.EnDescription;
            subMenuDtos.Description = subMenuResult.Description;
            subMenuDtos.Name = subMenuResult.Name;
            subMenuDtos.EnName = subMenuResult.EnName;
            subMenuDtos.IsActive = subMenuResult.IsActive;
            subMenuDtos.Id = subMenuResult.Id;
            return subMenuDtos;


        }
    }
}


 
 