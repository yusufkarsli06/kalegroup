
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
    public interface IFooterMenusLogic
    {
        List<FooterMenuDtos> GetFooterMenuList();
        void PasiveFooterMenu(int footerMenuId);
        void DeleteFooterMenu(int footerMenuId);
        void AddFooterMenu(FooterMenuDtos param);
        void UpdateFooterMenu(FooterMenuDtos param);
        FooterMenuDtos GetFooterMenu(int footerMenuId);
        FooterMenuDtos GetFooterMenuPageByPageUrl(string pageUrl);
    }
}
