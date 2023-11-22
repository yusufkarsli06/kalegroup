using KaleGroup.Data.Entities;

namespace KaleGroup.DataAccess.Repository.User.Interface
{
    public interface IUserRepository
    {
        bool AddUser(Users users);
        Users AuthenticateUser(string username, string password);
        bool ChangePassword(long userId, string password);
        Users GetUserInfo(long userId);

    }
}
