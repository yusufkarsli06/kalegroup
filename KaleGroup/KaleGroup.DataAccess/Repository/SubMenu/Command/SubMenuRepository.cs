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
            var subMenus = _dbSet.Where(x => x.Id == subMenu.Id).FirstOrDefault();

            subMenus.Name = subMenu.Name;
            subMenus.EnName = subMenu.EnName;
            subMenus.Description = subMenu.Description;
            subMenus.EnDescription = subMenu.EnDescription;            

            _dbContext.Entry(subMenus).State = EntityState.Modified;

            _dbContext.SaveChanges();

           
        }

        public void PasiveSubMenu(int subMenuId)
        {
            var subMenu = _dbSet.Where(x => x.Id == subMenuId).FirstOrDefault();
            if (subMenu.IsActive == false)
            {
                subMenu.IsActive = true;
            }
            else
            {
                subMenu.IsActive = false;
            }
          
            _dbContext.Entry(subMenu).State = EntityState.Modified;

            _dbContext.SaveChanges();

         
        }

        public List<SubMenus> GetSubMenuList()
        {
        
             return _dbSet.ToList();
        }

        public List<SubMenus> GetSubMenuListById(int menuId)
        {
            return _dbSet.Where(x => x.Id == menuId).ToList();
        }
    }
}

 
