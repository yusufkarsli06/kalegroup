using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using Microsoft.EntityFrameworkCore;

namespace KaleGroup.DataAccess.Repository.User.Command
{

    public class SubMenuRepository : Repository<SubMenus>, ISubMenuRepository
    {
        public SubMenuRepository() : base(new BaseContext())
        {
        }
        public SubMenuRepository(BaseContext dbContext) : base(dbContext)
        {
        }

     
        public void UpdateSubMenu(SubMenus subMenu)
        {
            var menu = _dbSet.Where(x => x.Id == subMenu.Id).FirstOrDefault();

            menu.Name = subMenu.Name;
            menu.Description = subMenu.Description;            

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

           
        }

        public void PasiveSubMenu(int subMenuId)
        {
            var menu = _dbSet.Where(x => x.Id == subMenuId).FirstOrDefault();

            menu.IsActive = false;            

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

         
        }

        public List<SubMenus> GetSubMenuList()
        {
        
             return _dbSet.Where(x => x.IsActive).ToList();
        }

        public List<SubMenus> GetSubMenuListById(int menuId)
        {
            return _dbSet.Where(x => x.IsActive && x.Id == menuId).ToList();
        }
    }
}

 
