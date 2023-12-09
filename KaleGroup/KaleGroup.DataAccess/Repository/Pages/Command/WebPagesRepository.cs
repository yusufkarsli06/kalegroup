using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.Pages.Interface;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.Pages.Command
{
    public class WebPagesRepository : Repository<WebPages>, IWebPagesRepository
    {
        public WebPagesRepository() : base(new BaseContext())
        {
        }
        public WebPagesRepository(BaseContext dbContext) : base(dbContext)
        {
        }
        public WebPages GetWebPageByPageUrl(string pageUrl)
        {
            var result= _dbSet.Where(x => x.PageUrl == pageUrl).FirstOrDefault();
            return result;
        }
        public List<WebPages> GetWebPageByMenuId(int menuId)
        {
            var result = _dbSet.Where(x => x.MenuId == menuId).ToList();
            return result;
        }
    }
}
 