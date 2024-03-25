using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.Menu.Command;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using Nest;

namespace KaleGroup.Business.Business
{
    public class FooterMenusLogic : IFooterMenusLogic
    {
        private readonly IFooterMenusRepository _footerMenusRepository;

        public FooterMenusLogic(IFooterMenusRepository footerMenusRepository)
        {
            _footerMenusRepository = footerMenusRepository;
        }

        public FooterMenuDtos GetFooterMenuPageByPageUrl(string pageUrl)
        {
            FooterMenuDtos footerMenuDtos = new FooterMenuDtos();

            var footerMenuResult = _footerMenusRepository.GetFooterMenuPageByPageUrl(pageUrl);

            footerMenuDtos.Id = footerMenuResult.Id;
            footerMenuDtos.PageName = footerMenuResult.PageName;
            footerMenuDtos.EnPageName = footerMenuResult.EnPageName;
            footerMenuDtos.PageUrl = footerMenuResult.PageUrl;
            footerMenuDtos.EnPageUrl = footerMenuResult.EnPageUrl;
            footerMenuDtos.FileUrl = footerMenuResult.FileUrl;
            footerMenuDtos.EnFileUrl = footerMenuResult.EnFileUrl;
            footerMenuDtos.IsActive = footerMenuResult.IsActive;
            footerMenuDtos.Description = footerMenuResult.Description;
            footerMenuDtos.EnDescription = footerMenuResult.EnDescription;
            footerMenuDtos.OrderNumber = footerMenuResult.OrderNumber;
            footerMenuDtos.PageTopSubject = footerMenuResult.PageTopSubject;
            footerMenuDtos.PageTopDescription = footerMenuResult.PageTopDescription; 
            footerMenuDtos.EnPageTopSubject = footerMenuResult.EnPageTopSubject;
            footerMenuDtos.EnPageTopDescription = footerMenuResult.EnPageTopDescription;
            footerMenuDtos.PageTopBackground = footerMenuResult.PageTopBackground;

            return footerMenuDtos;

        }
        public List<FooterMenuDtos> GetFooterMenuList()
        {
            List<FooterMenuDtos> footerMenuList = new List<FooterMenuDtos>();
            var footerMenuResult = _footerMenusRepository.GetAll().OrderBy(x => x.OrderNumber);
            foreach (var item in footerMenuResult)
            {
                FooterMenuDtos footerMenu = new FooterMenuDtos();

                footerMenu.Id = item.Id;
                footerMenu.PageName = item.PageName;
                footerMenu.EnPageName = item.EnPageName;
                footerMenu.PageUrl = item.PageUrl;
                footerMenu.EnPageUrl = item.EnPageUrl;
                footerMenu.FileUrl = item.FileUrl;
                footerMenu.EnFileUrl = item.EnFileUrl;
                footerMenu.IsActive = item.IsActive;
                footerMenu.Description = item.Description;
                footerMenu.EnDescription = item.EnDescription;
                footerMenu.OrderNumber = item.OrderNumber;
                footerMenu.PageTopSubject = item.PageTopSubject;
                footerMenu.PageTopBackground = item.PageTopBackground;
                footerMenu.PageTopDescription = item.PageTopDescription;
                footerMenu.EnPageTopSubject = item.EnPageTopSubject;
                footerMenu.EnPageTopDescription = item.EnPageTopDescription;
                footerMenuList.Add(footerMenu);
            }
            return footerMenuList;
        }
        public void PasiveFooterMenu(int footerMenuId)
        {
            _footerMenusRepository.PasiveFooterMenu(footerMenuId);
        }
        public void DeleteFooterMenu(int footerMenuId)
        {
            _footerMenusRepository.Delete(footerMenuId);
        }
        public void AddFooterMenu(FooterMenuDtos param)
        {
            FooterMenus footerMenu = new FooterMenus();
            footerMenu.PageName = param.PageName;
            footerMenu.EnPageName = param.EnPageName;
            footerMenu.PageUrl = param.PageUrl;
            footerMenu.EnPageUrl = param.EnPageUrl;
            footerMenu.FileUrl = param.FileUrl;
            footerMenu.EnFileUrl = param.EnFileUrl;
            footerMenu.IsActive = param.IsActive;
            footerMenu.Description = param.Description;
            footerMenu.EnDescription = param.EnDescription;
            footerMenu.OrderNumber = param.OrderNumber;
            footerMenu.PageTopSubject = param.PageTopSubject;
            footerMenu.PageTopBackground = param.PageTopBackground;
            footerMenu.PageTopDescription = param.PageTopDescription;
            footerMenu.EnPageTopSubject = param.EnPageTopSubject;
            footerMenu.EnPageTopDescription = param.EnPageTopDescription;
            _footerMenusRepository.Insert(footerMenu);
        }
        public void UpdateFooterMenu(FooterMenuDtos param)
        {
            FooterMenus footerMenu = new FooterMenus();
            footerMenu.Id = param.Id;
            footerMenu.PageName = param.PageName;
            footerMenu.EnPageName = param.EnPageName;
            footerMenu.PageUrl = param.PageUrl;
            footerMenu.EnPageUrl = param.EnPageUrl;
            footerMenu.FileUrl = param.FileUrl;
            footerMenu.EnFileUrl = param.EnFileUrl;
            footerMenu.IsActive = param.IsActive;
            footerMenu.Description = param.Description;
            footerMenu.EnDescription = param.EnDescription;
            footerMenu.OrderNumber = param.OrderNumber;
            footerMenu.PageTopSubject = param.PageTopSubject;
            footerMenu.PageTopBackground = param.PageTopBackground;
            footerMenu.PageTopDescription = param.PageTopDescription;
            footerMenu.EnPageTopSubject = param.EnPageTopSubject;
            footerMenu.EnPageTopDescription = param.EnPageTopDescription;
            _footerMenusRepository.Update(footerMenu);
        }
        public FooterMenuDtos GetFooterMenu(int footerMenuId)
        {
            FooterMenuDtos footerMenuDtos = new FooterMenuDtos();

            var footerMenuResult = _footerMenusRepository.GetById(footerMenuId);

            footerMenuDtos.Id = footerMenuResult.Id;
            footerMenuDtos.PageName = footerMenuResult.PageName;
            footerMenuDtos.EnPageName = footerMenuResult.EnPageName;
            footerMenuDtos.PageUrl = footerMenuResult.PageUrl;
            footerMenuDtos.EnPageUrl = footerMenuResult.EnPageUrl;
            footerMenuDtos.FileUrl = footerMenuResult.FileUrl;
            footerMenuDtos.EnFileUrl = footerMenuResult.EnFileUrl;
            footerMenuDtos.IsActive = footerMenuResult.IsActive;
            footerMenuDtos.Description = footerMenuResult.Description;
            footerMenuDtos.EnDescription = footerMenuResult.EnDescription;
            footerMenuDtos.OrderNumber = footerMenuResult.OrderNumber;
            footerMenuDtos.PageTopSubject = footerMenuResult.PageTopSubject;
            footerMenuDtos.PageTopBackground = footerMenuResult.PageTopBackground;
            footerMenuDtos.PageTopDescription = footerMenuResult.PageTopDescription;
            footerMenuDtos.EnPageTopSubject = footerMenuResult.EnPageTopSubject;
            footerMenuDtos.EnPageTopDescription = footerMenuResult.EnPageTopDescription;
            return footerMenuDtos;
        }
    }
}



