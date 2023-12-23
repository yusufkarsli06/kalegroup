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

        public DbSet<Users> Users { get; set; }
        public DbSet<SubMenus> SubMenus { get; set; }
        public DbSet<WebPages> WebPages { get; set; }
        public DbSet<UploadFiles> UploadFiles { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<Slider> Slider { get; set; }
        


    }
}
