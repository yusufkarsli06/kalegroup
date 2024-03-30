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
            var result = _dbSet.Where(x => x.PageUrl == pageUrl || x.EnPageUrl == pageUrl).FirstOrDefault();
            return result;
        }
        public List<WebPages> GetWebPageByMenuId(int menuId)
        {
            var result = _dbSet.Where(x => x.MenuId == menuId).ToList();
            return result;
        }
        public List<WebPages> GetWebPageByDetailList(bool isTopBody, bool isButtomBody, bool isNews)
        {
            if (isTopBody)
                return _dbSet.Where(x => x.IsTopBody && x.IsActive).ToList();

            if (isButtomBody)
                return _dbSet.Where(x => x.IsButtomBody && x.IsActive).ToList();

            if (isNews)
                return _dbSet.Where(x => x.IsNews && x.IsActive).ToList();


            return null;
        }

        public List<WebPages> GetWebSearchList(string language, string searchText)
        {
            //todo haberler önce çıkacak.
            if (language == "tr")
            {
                return _dbSet.Where(x =>
                 x.Name.Contains(searchText)
                ||  x.PageDescription.Contains(searchText)   
                ||  x.PageTopDescription.Contains(searchText) 
                ||  x.PageTopSubject.Contains(searchText)              
                 ).ToList();
            }
            else
            {

                return _dbSet.Where(x =>
                x.EnName.Contains(searchText)
               || x.EnPageDescription.Contains(searchText)
               || x.EnPageTopDescription.Contains(searchText)
               || x.EnPageTopSubject.Contains(searchText)
                ).ToList();

 

            }

        }

        public void PasivePage(int id)
        {
            var webPage = _dbSet.Where(x => x.Id == id).FirstOrDefault();

            if (webPage.IsActive == false)
            {
                webPage.IsActive = true;
            }
            else
            {
                webPage.IsActive = false;
            }


            _dbContext.Entry(webPage).State = EntityState.Modified;

            _dbContext.SaveChanges();


        }
    }
}
