using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.User.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.User.Command
{

    public class UserRepository: IUserRepository
    {
        private readonly IRepository<Users> _userRepository;
        private readonly BaseContext _dbContext;
        public UserRepository(IRepository<Users> userRepository, BaseContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;

        }
        public bool AddUser(Users users)
        {
            var result = _userRepository.InsertAsync(users);
            if (result != null)
                return true;

            return false;
        }
        public Users AuthenticateUser(string username, string password)
        {
            var model = _userRepository.Table.Where(x => x.Username == username && x.Password == password && x.IsActive).FirstOrDefault();

            return model;
        }
        public bool ChangePassword(long userId, string password)
        {
            var user = _userRepository.Table.Where(x => x.Id == userId).FirstOrDefault();

            user.Password = password;

            _dbContext.Entry(user).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return true;
        }

        public Users GetUserInfo(long userId)
        {
            return _userRepository.Table.Where(x => x.Id == userId).FirstOrDefault();
        }
    }
}


