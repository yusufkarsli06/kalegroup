
using KaleGroup.Business.Dto;
using KaleGroup.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.IBusiness
{
    public interface IUserLogic
    {
        bool AddUser(UserDtos users);
        bool AuthenticateUser(string username, string password);
        bool ChangePassword(long userId, string password);
        UserDtos GetUserInfo(long userId);
    }
}
