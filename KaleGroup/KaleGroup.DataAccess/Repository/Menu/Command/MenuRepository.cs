using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using KaleGroup.DataAccess.Repository.User.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.Menu.Command
{

    public class MenuRepository : IMenuRepository
    {
        private readonly IRepository<Menus> _menuRepository;
        private readonly BaseContext _dbContext;
        public MenuRepository(IRepository<Menus> menuRepository, BaseContext dbContext)
        {
            _menuRepository = menuRepository;
            _dbContext = dbContext;

        }
        public bool AddMenu(Menus subMenus)
        {
            var result = _menuRepository.InsertAsync(subMenus);
            if (result != null)
                return true;

            return false;
        }
   
        public bool UpdateMenu(Menus menus)
        {
            var menu = _menuRepository.Table.Where(x => x.Id == menus.Id).FirstOrDefault();

            menu.Name = menus.Name;
            menu.Description = menus.Description;
            menu.IsActive = menus.IsActive;
            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return true;
        }

        public bool PasiveMenu(int menuId)
        {
            var menu = _menuRepository.Table.Where(x => x.Id == menuId).FirstOrDefault();

            menu.IsActive = false;            

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return true;
        }

        public List<Menus> GetMenuList()
        {
            return _menuRepository.Table.Where(x=>x.IsActive).ToList();
        }
    }
}


 