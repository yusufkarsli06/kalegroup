using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;

namespace KaleGroup.DataAccess.Repository.SubMenu.Interface
{
    public interface IFooterMenusRepository: IRepository<FooterMenus> 
    {
        void PasiveFooterMenu(int footerMenuId);
        FooterMenus GetFooterMenuPageByPageUrl(string pageUrl);
    }
}
