using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;

namespace KaleGroup.DataAccess.Repository.User.Interface
{
    public interface IUserRepository : IRepository<Users>
    {
        Users AuthenticateUser(string username, string password);
        void ChangePassword(int userId, string password);

    }
}
