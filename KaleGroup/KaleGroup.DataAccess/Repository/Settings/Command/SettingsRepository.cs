using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.Settings.Interface;
using KaleGroup.DataAccess.Repository.Slider.Interface;
using Microsoft.EntityFrameworkCore;
 

namespace KaleGroup.DataAccess.Repository.Slider.Command
{
    public class SettingsRepository : Repository<Data.Entities.Settings>, ISettingsRepository
    {
        public SettingsRepository() : base(new BaseContext())
        {
        }
        public SettingsRepository(BaseContext dbContext) : base(dbContext)
        {
        } 
       
    }
}
