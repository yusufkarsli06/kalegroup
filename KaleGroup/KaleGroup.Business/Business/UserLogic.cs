using KaleGroup.Business.Dto;
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
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(UserDtos users)
        {
            Users user = new Users();
            user.Username = users.Username;
            user.Email = users.Email;
            user.IsActive =true;
            user.Password = HashHelper.ComputeSha256Hash(users.Password);  
           
            return _userRepository.AddUser(user);
        }
        public bool AuthenticateUser(string username, string password)
        {          
            var user =  _userRepository.AuthenticateUser(username, HashHelper.ComputeSha256Hash(password));

            if(user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangePassword(long userId, string password)
        {         
            return _userRepository.ChangePassword(userId, HashHelper.ComputeSha256Hash(password));
        }
        public UserDtos GetUserInfo(long userId)
        {
            var user =  _userRepository.GetUserInfo(userId);

            UserDtos userDtos = new UserDtos();
            userDtos.Username = user.Username;
            userDtos.Email= user.Email;
            return userDtos;

        }
    }
}


 
 