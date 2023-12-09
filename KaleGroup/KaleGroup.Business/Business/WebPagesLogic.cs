using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.Pages.Interface;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;

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


            return webPage;
        }

        public List<WebPagesDtos> GetWebPageByMenuId(int menuId)

        {
            List<WebPagesDtos> webPageList = new List<WebPagesDtos>();
            var webPageResult = _webPagesRepository.GetWebPageByMenuId(menuId);

            foreach (var item in webPageResult)
            {
                WebPagesDtos webPage = new WebPagesDtos();
                webPage.PageTopDescription = item.PageTopDescription;
                webPage.EnPageTopDescription = item.EnPageTopDescription;
               
                webPage.PageUrl = item.PageUrl;
                webPage.EnPageUrl = item.EnPageUrl;
                webPage.PageTopImages = item.PageTopImages;
                

                webPageList.Add(webPage);

            }
            return webPageList;
        }

        //public void PasiveSubMenu(int subMenuId)
        //{
        //    _subMenuRepository.PasiveSubMenu(subMenuId);
        //}

        //public void DeleteSubMenu(int subMenuId)
        //{
        //    _subMenuRepository.Delete(subMenuId);
        //}
        //public void AddSubMenu(SubMenuDtos param)
        //{
        //    SubMenus subMenus = new SubMenus();
        //    subMenus.Name = param.Name;
        //    subMenus.Description = param.Description;
        //    subMenus.EnDescription = param.EnDescription;
        //    subMenus.EnName = param.EnName;
        //    subMenus.IsActive = true;
        //    subMenus.MenuId = param.MenuId;
        //    _subMenuRepository.Insert(subMenus);
        //}

        //public void UpdateSubMenu(SubMenuDtos param)
        //{
        //    SubMenus subMenus = new SubMenus();
        //    subMenus.Name = param.Name;
        //    subMenus.Description = param.Description;
        //    subMenus.EnDescription = param.EnDescription;
        //    subMenus.EnName = param.EnName;
        //    subMenus.IsActive = true;
        //    subMenus.MenuId = param.MenuId;
        //    _subMenuRepository.Update(subMenus);
        //}

        //public SubMenuDtos GetSubMenu(int subMenuId)
        //{
        //    SubMenuDtos subMenuDtos = new SubMenuDtos();

        //    var subMenuResult = _subMenuRepository.GetById(subMenuId);

        //    subMenuDtos.EnDescription = subMenuResult.EnDescription;
        //    subMenuDtos.Description = subMenuResult.Description;
        //    subMenuDtos.Name = subMenuResult.Name;
        //    subMenuDtos.EnName = subMenuResult.EnName;
        //    subMenuDtos.IsActive = subMenuResult.IsActive;
        //    subMenuDtos.Id = subMenuResult.Id;
        //    return subMenuDtos;


        //}
    }
}



