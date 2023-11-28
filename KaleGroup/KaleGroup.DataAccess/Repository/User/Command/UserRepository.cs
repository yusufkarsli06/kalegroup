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

    public class UserRepository: Repository<Users>,IUserRepository
    {
        public UserRepository() : base(new BaseContext())
        { 
        }
        public UserRepository(BaseContext dbContext):base(dbContext) 
        {
        }
        public Users AuthenticateUser(string username, string password)
        {
            var model = _dbSet.Where(x => x.Username == username && x.Password == password && x.IsActive).FirstOrDefault();

            return model;
        }
        public void ChangePassword(int userId, string password)
        {
            var user = _dbSet.Where(x => x.Id == userId).FirstOrDefault();

            user.Password = password;

            _dbContext.Entry(user).State = EntityState.Modified;

            _dbContext.SaveChanges();

        }
    }
}


