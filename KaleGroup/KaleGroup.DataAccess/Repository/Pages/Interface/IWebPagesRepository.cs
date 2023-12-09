using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.Pages.Interface
{
    public interface   IWebPagesRepository : IRepository<WebPages>
    {
        WebPages GetWebPageByPageUrl(string pageUrl);
        List<WebPages> GetWebPageByMenuId(int menuId);
    }
}
 