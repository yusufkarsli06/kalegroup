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

                webPageList.Add(webPage);

            }
            return webPageList;
        }

        public WebPagesDtos GetWebPageByPageUrl(string pageUrl)

        {
            var pageResult = _webPagesRepository.GetWebPageByPageUrl(pageUrl);

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

            webPage.EnPageTopSubject = pageResult.EnPageTopSubject;
            webPage.EnPageTopSubject = pageResult.EnPageTopSubject;
            webPage.EnPageTopDescription = pageResult.EnPageTopDescription;
            webPage.EnPageTopBackground = pageResult.EnPageTopBackground;
            webPage.EnPageDescription = pageResult.EnPageDescription;
            webPage.EnPageUrl = pageResult.EnPageUrl;
            webPage.IsMenu = pageResult.IsMenu;
            webPage.IsSubMenu = pageResult.IsSubMenu;


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


                webPageList.Add(webPage);

            }
            return webPageList;
        }
    }
}



