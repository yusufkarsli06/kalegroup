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

        public void AddUser(UserDtos users)
        {
            Users user = new Users();
            user.Username = users.Username;
            user.Email = users.Email;
            user.IsActive =true;
            user.Password = HashHelper.ComputeSha256Hash(users.Password);  
           
            _userRepository.Insert(user);
        }
        public UserDtos AuthenticateUser(string username, string password)
        {          
            var user =  _userRepository.AuthenticateUser(username, HashHelper.ComputeSha256Hash(password));
            if (user != null)
            {
                UserDtos userDtos = new UserDtos();
                userDtos.Id = user.Id;
                userDtos.Username = user.Username;
                userDtos.Email = user.Email;

                return userDtos;
            }
            else
            {
                return null;
            }

        }
        public void ChangePassword(int userId, string password)
        {         
            _userRepository.ChangePassword(userId, HashHelper.ComputeSha256Hash(password));
        }
        public UserDtos GetUserInfo(int userId)
        {
            var user =  _userRepository.GetById(userId);

            UserDtos userDtos = new UserDtos();
            userDtos.Id = user.Id;
            userDtos.Username = user.Username;
            userDtos.Email= user.Email;
            userDtos.IsActive= user.IsActive;
            return userDtos;

        }
        public List<UserDtos> GetUserList()
        {
            List<UserDtos> userDtos= new List<UserDtos>();
            var user = _userRepository.GetAll();
            foreach (var item in user)
            {
                UserDtos userDto = new UserDtos();
                userDto.Username = item.Username;
                userDto.Email = item.Email;
                userDto.IsActive = item.IsActive;
                userDto.Id = item.Id;
                userDtos.Add(userDto);
            }
            return userDtos;

        }

        public void PasiveUser(int userId)
        {
            _userRepository.PasiveUser(userId);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }

        public void UpdateUser(UserDtos param)
        {
            Users users = new Users();

            users.Id = param.Id;
            users.Username = param.Username;
            users.Email = param.Email;
            users.Password = HashHelper.ComputeSha256Hash(param.Password); 
            users.IsActive = param.IsActive;

            _userRepository.Update(users);
        }


        public bool CheckUser(int userId, string password)
        {
            var user = _userRepository.CheckUser(userId, HashHelper.ComputeSha256Hash(password));

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


 
 