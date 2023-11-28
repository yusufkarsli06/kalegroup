using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using KaleGroup.DataAccess.Repository.User.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.Menu.Command
{
    
    public class MenuRepository : Repository<Menus>, IMenuRepository
    {
        public MenuRepository() : base(new BaseContext())
        {
        }
        public MenuRepository(BaseContext dbContext) : base(dbContext)
        {
        }
       
     
   
        public void UpdateMenu(Menus menus)
        {
            var menu = _dbSet.Where(x => x.Id == menus.Id).FirstOrDefault();

            menu.Name = menus.Name;
            menu.Description = menus.Description;
            menu.IsActive = menus.IsActive;
            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();
             
        }

        public void PasiveMenu(int menuId)
        {
            var menu = _dbSet.Where(x => x.Id == menuId).FirstOrDefault();

            menu.IsActive = false;            

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

           
        }

        public List<Menus> GetMenuList()
        {
            return _dbSet.Where(x=>x.IsActive).ToList();
        }
    }
}

 