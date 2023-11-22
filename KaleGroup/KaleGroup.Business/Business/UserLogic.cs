using KaleGroup.Business.IBusiness;
using KaleGroup.Common.Helper;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.User.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Business
{
    public class UserLogic : IUserLogic
    {
        private readonly ISubMenuRepository _userRepository;

        public UserLogic(ISubMenuRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(Users users)
        {
            users.Password = HashHelper.ComputeSha256Hash(users.Password);
            return _userRepository.AddUser(users);
        }
        public Users AuthenticateUser(string username, string password)
        {          
            return _userRepository.AuthenticateUser(username, HashHelper.ComputeSha256Hash(password));
        }
        public bool ChangePassword(long userId, string password)
        {         
            return _userRepository.ChangePassword(userId, HashHelper.ComputeSha256Hash(password));
        }
        public Users GetUserInfo(long userId)
        {
            return _userRepository.GetUserInfo(userId);
        }
    }
}


 
 