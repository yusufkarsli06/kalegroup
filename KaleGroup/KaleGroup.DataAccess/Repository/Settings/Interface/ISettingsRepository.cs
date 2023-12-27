using KaleGroup.DataAccess.Abstract;

namespace KaleGroup.DataAccess.Repository.Settings.Interface
{
    public interface ISettingsRepository : IRepository<Data.Entities.Settings>
    {
        void PasiveSettings(int id);
    }
}
