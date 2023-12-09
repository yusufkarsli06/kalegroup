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
       
     
  
        public void PasiveMenu(int menuId)
        {
            var menu = _dbSet.Where(x => x.Id == menuId).FirstOrDefault();
            if (menu.IsActive == false)
            {
                menu.IsActive = true;
            }
            else
            {
                menu.IsActive = false;
            }
                   

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

           
        }
 
    }
}

 