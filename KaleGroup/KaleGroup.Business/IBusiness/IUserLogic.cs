﻿
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
        void AddUser(UserDtos users);
        UserDtos AuthenticateUser(string username, string password);
        void ChangePassword(int userId, string password);
        UserDtos GetUserInfo(int userId);
        List<UserDtos> GetUserList();
        void PasiveUser(int userId);
        void DeleteUser(int userId);
        void UpdateUser(UserDtos users);
        bool CheckUser(int userId, string password);
    }
}
