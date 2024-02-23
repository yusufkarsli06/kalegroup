using KaleGroup.Admin.Models;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaleGroup.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly IUserLogic _userLogic;
        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;

        }
        public IActionResult Index()
        {
            List<UserViewModel> vm = new List<UserViewModel>();


            var userResult = _userLogic.GetUserList();


            foreach (var item in userResult)
            {
                UserViewModel user = new UserViewModel();

                user.Id = item.Id;
                user.Username = item.Username;
                user.Email = item.Email;
                user.IsActive = item.IsActive;
                vm.Add(user);
            }

            return View(vm);

        }

        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            AddUserViewModel vm = new AddUserViewModel();
            vm.IsActive = true;
            return View(vm);
          
        }

        [HttpPost]
        public IActionResult AddUser(AddUserViewModel param)
        {
            UserDtos userDtos = new UserDtos();
            userDtos.Username = param.Username;
            userDtos.Email = param.Email;
            userDtos.Password = param.Password;
            userDtos.IsActive = param.IsActive;
            _userLogic.AddUser(userDtos);
            return RedirectToAction("Index");            
        }

        public IActionResult DeleteUser(int userId)
        {
            _userLogic.DeleteUser(userId);
            return RedirectToAction("Index");
        }
        public IActionResult PasiveUser(int userId)
        {
            _userLogic.PasiveUser(userId);
            return RedirectToAction("Index");
        }
  
        public IActionResult ChangePasswordUser(int userId)
        {
            ChangeUserViewModel vm = new ChangeUserViewModel();
            var userDtos = _userLogic.GetUserInfo(userId);
 
            vm.Id = userDtos.Id;

            return View(vm);
        }

        [HttpPost]
        public IActionResult ChangePasswordUser(ChangeUserViewModel param)
        {
            if (param.NewPassword == param.NewRepeatPassword)
            {

                var userCheck = _userLogic.CheckUser(param.Id, param.OldPassword);

                if (userCheck)
                {
                    _userLogic.ChangePassword(param.Id, param.NewPassword);
                }
                else
                {
                    //todo eski şifre yanlış
                }

            }
            else
            {
                //todo şifreler eşleşmiyor.
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdateUser(int userId)
        {
            AddUserViewModel vm = new AddUserViewModel();
            var userDtos = _userLogic.GetUserInfo(userId);

            vm.Email = userDtos.Email;
            vm.Username = userDtos.Username;
            vm.IsActive = userDtos.IsActive;
            vm.Id = userDtos.Id;

            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateUser(AddUserViewModel param)
        {
            UserDtos userDtos = new UserDtos();
            userDtos.Username = param.Username;
            userDtos.Email = param.Email;
            userDtos.Password = param.Password;  
            userDtos.Id = param.Id;
            userDtos.IsActive = param.IsActive;

            _userLogic.UpdateUser(userDtos);

            return RedirectToAction("Index");
        }
    }
}