using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;

namespace KaleGroup.DataAccess.Repository.SubMenu.Interface
{
    public interface IMenuRepository: IRepository<Menus> 
    {
       
        void UpdateMenu(Menus subMenu);
        void PasiveMenu(int menuId);
        List<Menus> GetMenuList();

    }
}
