using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using Microsoft.EntityFrameworkCore;

namespace KaleGroup.DataAccess.Repository.User.Command
{

    public class SubMenuRepository : ISubMenuRepository
    {
        private readonly IRepository<SubMenus> _SubMenuRepository;
        private readonly BaseContext _dbContext;
        public SubMenuRepository(IRepository<SubMenus> SubMenuRepository, BaseContext dbContext)
        {
            _SubMenuRepository = SubMenuRepository;
            _dbContext = dbContext;

        }
        public bool AddSubMenu(SubMenus subMenu)
        {
            var result = _SubMenuRepository.InsertAsync(subMenu);
            if (result != null)
                return true;

            return false;
        }
   
        public bool UpdateSubMenu(SubMenus subMenu)
        {
            var menu = _SubMenuRepository.Table.Where(x => x.Id == subMenu.Id).FirstOrDefault();

            menu.Name = subMenu.Name;
            menu.Description = subMenu.Description;            

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return true;
        }

        public bool PasiveSubMenu(int subMenuId)
        {
            var menu = _SubMenuRepository.Table.Where(x => x.Id == subMenuId).FirstOrDefault();

            menu.IsActive = false;            

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return true;
        }

        public List<SubMenus> GetSubMenuList(int subMenuId)
        {
            return _SubMenuRepository.Table.Where(x=>x.IsActive && x.Id == subMenuId).ToList();
        }
    }
}

 
