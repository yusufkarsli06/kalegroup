﻿
using KaleGroup.Business.Dto;
using KaleGroup.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.IBusiness
{
    public interface IWebPagesLogic
    {
        List<WebPagesDtos> GetAllWebPagesList();
        WebPagesDtos GetWebPageByPageUrl(string pageUrl);
        List<WebPagesDtos> GetWebPageByMenuId(int menuId);
        List<WebPagesDtos> GetWebPageByDetailList(bool isTopBody = false, bool isButtomBody = false, bool isNews = false);
        List<WebPagesDtos> GetWebSearchList(string language, string searchText);
        void AddWebPages(WebPagesDtos param);
        WebPagesDtos GetWebPageById(int id);
        void UpdateWebPages(WebPagesDtos param);
        void PasivePage(int id);
        void DeletePage(int id);
    }
}
 