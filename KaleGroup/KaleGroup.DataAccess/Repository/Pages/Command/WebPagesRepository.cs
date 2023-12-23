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
            var result= _dbSet.Where(x => x.PageUrl == pageUrl || x.EnPageUrl==pageUrl).FirstOrDefault();
            return result;
        }
        public List<WebPages> GetWebPageByMenuId(int menuId)
        {
            var result = _dbSet.Where(x => x.MenuId == menuId).ToList();
            return result;
        }
        public List<WebPages> GetWebPageByDetailList(bool isTopBody, bool isButtomBody, bool isNews)
        {
            if(isTopBody)
            return  _dbSet.Where(x => x.IsTopBody).ToList();   
            
            if(isButtomBody)
            return  _dbSet.Where(x => x.IsButtomBody).ToList();  
            
            if(isNews)
            return  _dbSet.Where(x => x.IsNews).ToList();


            return null;
        }

        public List<WebPages> GetWebSearhList(string language,string searchText)
        {
            //todo haberler önce çıkacak.
            if (language == "tr")
            {
                return _dbSet.Where(x => searchText.Contains(x.Name) 
                || searchText.Contains(x.PageDescription)
                || searchText.Contains(x.PageTopDescription)
                || searchText.Contains(x.PageTopSubject)
                 ).OrderBy(x => x.IsNews).ToList();
            }
            else
            {
                return _dbSet.Where(x => searchText.Contains(x.EnName)
                || searchText.Contains(x.EnPageDescription)
                || searchText.Contains(x.EnPageTopDescription)
                || searchText.Contains(x.EnPageTopSubject)
                ).OrderBy(x=>x.IsNews).ToList();

            }
 
        }
    }
}
 