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

namespace KaleGroup.DataAccess.Repository.User.Command
{

    public class SubMenuRepository : ISubMenuRepository
    {
        private readonly IRepository<SubMenu> _subMenuRepository;
        private readonly BaseContext _dbContext;
        public SubMenuRepository(IRepository<SubMenu> subMenuRepository, BaseContext dbContext)
        {
            _subMenuRepository = subMenuRepository;
            _dbContext = dbContext;

        }
        public bool AddSubMenu(SubMenu subMenus)
        {
            var result = _subMenuRepository.InsertAsync(subMenus);
            if (result != null)
                return true;

            return false;
        }
   
        public bool UpdateSubMenu(SubMenu subMenus)
        {
            var menu = _subMenuRepository.Table.Where(x => x.Id == subMenus.Id).FirstOrDefault();

            menu.Name = subMenus.Name;
            menu.Description = subMenus.Description;            

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return true;
        }

        public bool DeleteSubMenu(int subMenuId)
        {
            var menu = _subMenuRepository.Table.Where(x => x.Id == subMenuId).FirstOrDefault();

            menu.IsActive = false;            

            _dbContext.Entry(menu).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return true;
        }

        public List<SubMenu> GetSubMenuList(int subMenuId)
        {
            return _subMenuRepository.Table.Where(x=>x.IsActive && x.Id == subMenuId).ToList();
        }
    }
}


 