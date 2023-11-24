using KaleGroup.Data.Entities;

namespace KaleGroup.DataAccess.Repository.SubMenu.Interface
{
    public interface IMenuRepository
    {
        bool AddMenu(Menus subMenu);
        List<Menus> GetMenuList();
        bool UpdateMenu(Menus subMenu);
        bool PasiveMenu(int menuId);

    }
}
