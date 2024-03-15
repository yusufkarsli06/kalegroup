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
    
    public class FooterMenusRepository : Repository<FooterMenus>, IFooterMenusRepository
    {
        public FooterMenusRepository() : base(new BaseContext())
        {
        }
        public FooterMenusRepository(BaseContext dbContext) : base(dbContext)
        {
        }
        public FooterMenus GetFooterMenuPageByPageUrl(string pageUrl)
        {
            var result = _dbSet.Where(x => x.PageUrl == pageUrl || x.EnPageUrl == pageUrl).FirstOrDefault();
            return result;
        }

        public void PasiveFooterMenu(int footerMenuId)
        {
            var menu = _dbSet.Where(x => x.Id == footerMenuId).FirstOrDefault();
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

 