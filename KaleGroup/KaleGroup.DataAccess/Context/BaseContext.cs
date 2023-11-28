using KaleGroup.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> User { get; set; }
        public DbSet<SubMenus> SubMenus { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Menus> Menus { get; set; }
        


    }
}
