using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.Pages.Interface;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using Nest;

namespace KaleGroup.Business.Business
{
    public class WebPagesLogic : IWebPagesLogic
    {
        private readonly IWebPagesRepository _webPagesRepository;

        public WebPagesLogic(IWebPagesRepository webPagesRepository)
        {
            _webPagesRepository = webPagesRepository;
        }

        public List<WebPagesDtos> GetAllWebPagesList()

        {
            List<WebPagesDtos> webPageList = new List<WebPagesDtos>();
            var webPageResult = _webPagesRepository.GetAll();

            foreach (var item in webPageResult)
            {
                WebPagesDtos webPage = new WebPagesDtos();
                webPage.Name = item.Name;
                webPage.EnName = item.EnName;
                webPage.MenuId = item.MenuId;
                webPage.PageUrl = item.PageUrl;
                webPage.IsMenu = item.IsMenu;
                webPage.IsSubMenu = item.IsSubMenu;
                webPage.IsActive = item.IsActive;
                webPage.Id = item.Id;

                webPageList.Add(webPage);

            }
            return webPageList;
        }

        public WebPagesDtos GetWebPageByPageUrl(string pageUrl)

        {
            var pageResult = _webPagesRepository.GetWebPageByPageUrl(pageUrl);
            if (pageResult == null)
                return null;


            WebPagesDtos webPage = new WebPagesDtos();

            webPage.Id = pageResult.Id;
            webPage.Name = pageResult.Name;
            webPage.MenuId = pageResult.MenuId;
            webPage.EnName = pageResult.EnName;
            webPage.PageTopSubject = pageResult.PageTopSubject;
            webPage.PageTopBackground = pageResult.PageTopBackground;
            webPage.PageTopDescription = pageResult.PageTopDescription;
            webPage.EnPageTopDescription = pageResult.EnPageTopDescription;
            webPage.PageTopImages = pageResult.PageTopImages;
            webPage.PageDescription = pageResult.PageDescription;
            webPage.PageUrl = pageResult.PageUrl;
            webPage.Keyword = pageResult.Keyword;
            webPage.EnKeyword = pageResult.EnKeyword;

            webPage.EnPageTopSubject = pageResult.EnPageTopSubject;
            webPage.EnPageTopSubject = pageResult.EnPageTopSubject;
            webPage.EnPageTopDescription = pageResult.EnPageTopDescription;
            webPage.EnPageTopBackground = pageResult.EnPageTopBackground;
            webPage.EnPageDescription = pageResult.EnPageDescription;
            webPage.EnPageUrl = pageResult.EnPageUrl;
            webPage.IsMenu = pageResult.IsMenu;
            webPage.IsSubMenu = pageResult.IsSubMenu;
            webPage.IsSlider = pageResult.IsSlider;


            return webPage;
        }

        public List<WebPagesDtos> GetWebPageByMenuId(int menuId)

        {
            List<WebPagesDtos> webPageList = new List<WebPagesDtos>();
            var webPageResult = _webPagesRepository.GetWebPageByMenuId(menuId);

            foreach (var item in webPageResult)
            {
                WebPagesDtos webPage = new WebPagesDtos();
                webPage.Id = item.Id;
                webPage.Name = item.Name;
                webPage.MenuId = item.MenuId;
                webPage.EnName = item.EnName;
                webPage.PageTopSubject = item.PageTopSubject;
                webPage.PageTopBackground = item.PageTopBackground;
                webPage.PageTopDescription = item.PageTopDescription;
                webPage.EnPageTopDescription = item.EnPageTopDescription;
                webPage.PageTopImages = item.PageTopImages;
                webPage.PageDescription = item.PageDescription;
                webPage.PageUrl = item.PageUrl;
                webPage.Keyword = item.Keyword;

                webPage.EnPageTopSubject = item.EnPageTopSubject;
                webPage.EnPageTopDescription = item.EnPageTopDescription;
                webPage.EnPageTopBackground = item.EnPageTopBackground;
                webPage.EnPageDescription = item.EnPageDescription;
                webPage.EnPageUrl = item.EnPageUrl;
                webPage.IsMenu = item.IsMenu;
                webPage.IsSubMenu = item.IsSubMenu;
                webPage.IsSlider = item.IsSlider;


                webPageList.Add(webPage);

            }
            return webPageList;
        }

        public List<WebPagesDtos> GetWebPageByDetailList(bool isTopBody = false, bool isButtomBody = false, bool isNews = false)

        {
            List<WebPagesDtos> webPageList = new List<WebPagesDtos>();
            var webPageResult = _webPagesRepository.GetWebPageByDetailList(isTopBody, isButtomBody, isNews);

            foreach (var item in webPageResult)
            {
                WebPagesDtos webPage = new WebPagesDtos();
                webPage.Id = item.Id;
                webPage.Name = item.Name;
                webPage.EnName = item.EnName;
                webPage.PageTopSubject = item.PageTopSubject;
                webPage.PageTopDescription = item.PageTopDescription;
                webPage.EnPageTopDescription = item.EnPageTopDescription;
                webPage.PageTopImages = item.PageTopImages;
                webPage.PageDescription = item.PageDescription;
                webPage.PageUrl = item.PageUrl;

                webPage.EnPageTopSubject = item.EnPageTopSubject;
                webPage.EnPageTopDescription = item.EnPageTopDescription;
                webPage.EnPageTopBackground = item.EnPageTopBackground;
                webPage.EnPageDescription = item.EnPageDescription;
                webPage.EnPageUrl = item.EnPageUrl;
                webPage.CreatedAt = item.CreatedAt;
                webPage.IsSubMenu = item.IsSubMenu;
                webPage.IsSlider = item.IsSlider;
                webPage.HomeImage = item.HomeImage;


                webPageList.Add(webPage);

            }
            return webPageList;
        }

        public List<WebPagesDtos> GetWebSearchList(string language, string searchText)
        {
            List<WebPagesDtos> webPageList = new List<WebPagesDtos>();
            var webPageResult = _webPagesRepository.GetWebSearchList(language, searchText);

            foreach (var item in webPageResult)
            {
                WebPagesDtos webPage = new WebPagesDtos();
                webPage.Id = item.Id;
                webPage.Name = item.Name;
                webPage.EnName = item.EnName;
                webPage.PageTopSubject = item.PageTopSubject;
                webPage.PageTopDescription = item.PageTopDescription;
                webPage.EnPageTopDescription = item.EnPageTopDescription;
                webPage.PageUrl = item.PageUrl;
                webPage.MenuId = item.MenuId;

                webPage.EnPageTopSubject = item.EnPageTopSubject;
                webPage.EnPageTopDescription = item.EnPageTopDescription;
                webPage.EnPageUrl = item.EnPageUrl;
                webPage.IsSlider = item.IsSlider;


                webPageList.Add(webPage);

            }
            return webPageList;
        }

        public void AddWebPages(WebPagesDtos param)

        {

            WebPages webPages = new WebPages();


            webPages.Name = param.Name;
            webPages.MenuId = param.MenuId;
            webPages.PageTopSubject = param.PageTopSubject;
            webPages.PageTopDescription = param.PageTopDescription;
            webPages.PageTopBackground = param.PageTopBackground;
            webPages.PageTopImages = param.PageTopImages;
            webPages.PageDescription = param.PageDescription;
            webPages.IsActive = true;
            webPages.PageUrl = param.PageUrl;
            webPages.Keyword = param.Keyword;
            webPages.EnName = param.EnName;
            webPages.EnPageTopSubject = param.EnPageTopSubject;
            webPages.EnPageTopDescription = param.EnPageTopDescription;
            webPages.EnPageTopBackground = param.EnPageTopBackground;
            webPages.EnPageDescription = param.EnPageDescription;
            webPages.EnPageUrl = param.EnPageUrl;
            webPages.IsNews = param.IsNews;
            webPages.IsSubMenu = param.IsSubMenu;
            webPages.IsMenu = param.IsMenu;
            webPages.IsTopBody = param.IsTopBody;
            webPages.IsButtomBody = param.IsButtomBody;
            webPages.CreatedAt = param.CreatedAt;
            webPages.EnKeyword = param.EnKeyword;
            webPages.IsSlider = param.IsSlider;
            webPages.HomeImage = param.HomeImage; 

            _webPagesRepository.Insert(webPages);
        }

        public WebPagesDtos GetWebPageById(int id)

        {
            var pageResult = _webPagesRepository.GetById(id);

            WebPagesDtos webPage = new WebPagesDtos();

            webPage.Id = pageResult.Id;
            webPage.Name = pageResult.Name;
            webPage.MenuId = pageResult.MenuId;
            webPage.PageTopSubject = pageResult.PageTopSubject;
            webPage.PageTopDescription = pageResult.PageTopDescription;
            webPage.PageTopBackground = pageResult.PageTopBackground;
            webPage.PageTopImages = pageResult.PageTopImages;
            webPage.PageDescription = pageResult.PageDescription;
            webPage.IsActive = pageResult.IsActive;
            webPage.PageUrl = pageResult.PageUrl;
            webPage.Keyword = pageResult.Keyword;
            webPage.EnName = pageResult.EnName;
            webPage.EnPageTopSubject = pageResult.EnPageTopSubject;
            webPage.EnPageTopDescription = pageResult.EnPageTopDescription;
            webPage.EnPageTopBackground = pageResult.EnPageTopBackground;
            webPage.EnPageDescription = pageResult.EnPageDescription;
            webPage.EnPageUrl = pageResult.EnPageUrl;
            webPage.IsNews = pageResult.IsNews;
            webPage.IsSubMenu = pageResult.IsSubMenu;
            webPage.IsMenu = pageResult.IsMenu;
            webPage.IsTopBody = pageResult.IsTopBody;
            webPage.IsButtomBody = pageResult.IsButtomBody;
            webPage.CreatedAt = pageResult.CreatedAt;
            webPage.EnKeyword = pageResult.EnKeyword;
            webPage.IsSlider = pageResult.IsSlider;
            webPage.HomeImage = pageResult.HomeImage;

            return webPage;
        }

        public void UpdateWebPages(WebPagesDtos param)
        {

            WebPages webPages = new WebPages();

            webPages.Id = param.Id;
            webPages.Name = param.Name;
            webPages.MenuId = param.MenuId;
            webPages.PageTopSubject = param.PageTopSubject;
            webPages.PageTopDescription = param.PageTopDescription;
            webPages.PageTopBackground = param.PageTopBackground;
            webPages.PageTopImages = param.PageTopImages;
            webPages.PageDescription = param.PageDescription;
            webPages.IsActive = param.IsActive;
            webPages.PageUrl = param.PageUrl;
            webPages.Keyword = param.Keyword;
            webPages.EnName = param.EnName;
            webPages.EnPageTopSubject = param.EnPageTopSubject;
            webPages.EnPageTopDescription = param.EnPageTopDescription;
            webPages.EnPageTopBackground = param.EnPageTopBackground;
            webPages.EnPageDescription = param.EnPageDescription;
            webPages.EnPageUrl = param.EnPageUrl;
            webPages.IsNews = param.IsNews;
            webPages.IsSubMenu = param.IsSubMenu;
            webPages.IsMenu = param.IsMenu;
            webPages.IsTopBody = param.IsTopBody;
            webPages.IsButtomBody = param.IsButtomBody;
            webPages.CreatedAt = param.CreatedAt;
            webPages.EnKeyword = param.EnKeyword;
            webPages.IsSlider = param.IsSlider;
            webPages.HomeImage = param.HomeImage;
            webPages.CreatedAt = DateTime.Now;

            _webPagesRepository.Update(webPages);
        }
        public void PasivePage(int id)
        {
            _webPagesRepository.PasivePage(id);
        }
        public void DeletePage(int id)
        {

            var filePath = _webPagesRepository.GetById(id);

            _webPagesRepository.Delete(id);


            if (File.Exists(@"../KaleGroup.Web/wwwroot/" + filePath.PageTopImages))
            {
                File.Delete(@"../KaleGroup.Web/wwwroot/" + filePath.PageTopImages);
            }
        }
    }
}



