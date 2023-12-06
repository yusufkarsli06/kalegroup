using KaleGroup.Business.Business;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Diagnostics;
using System.Security.Claims;

namespace KaleGroup.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuLogic _menuLogic;
        private readonly IUserLogic _userLogic;
        private readonly ISubMenuLogic _subMenuLogic;

        public HomeController(ILogger<HomeController> logger,
          IMenuLogic menuLogic, ISubMenuLogic subMenuLogic, IUserLogic userLogic
            )
        {
            _logger = logger;
            _subMenuLogic = subMenuLogic;
            _menuLogic = menuLogic;
            _userLogic = userLogic;
        }
        public IActionResult Login()
        {
            LoginViewModel vm = new LoginViewModel();
            return View(vm);
        }
        public IActionResult Index()
        {
            List<MenuViewModel> vm = new List<MenuViewModel>();


            var menuResult = _menuLogic.GetMenuList().Where(x => x.IsActive).ToList();
            var subMenuResult = _subMenuLogic.GetSubMenuList().Where(x => x.IsActive).ToList();

            foreach (var item in menuResult)
            {
                List<SubMenuViewModel> subMenuList = new List<SubMenuViewModel>();
                MenuViewModel menu = new MenuViewModel();
                menu.Name = item.Name;
                menu.EnName = item.EnName;
                var subMenuListNew = subMenuResult.Where(x => x.MenuId == item.Id).ToList();

                foreach (var subItem in subMenuListNew)
                {
                    SubMenuViewModel subMenu = new SubMenuViewModel();
                    subMenu.Name = subItem.Name;
                    subMenu.EnName = subItem.EnName;
                    subMenu.MenuId = subItem.MenuId;
                    subMenuList.Add(subMenu);
                }
                menu.SubMenuViewModels = subMenuList;
                vm.Add(menu);
            }

            return View(vm);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel param)
        {

          var loginResult = _userLogic.AuthenticateUser(param.Username, param.Password);

            if (loginResult!=null)
            {

                Claim[] claims = new Claim[]
                   {
                            new Claim(ClaimTypes.Name,loginResult.Username), 
                            new Claim("EndDate",  DateTime.MinValue.AddDays(30).ToString()),
                            new Claim(ClaimTypes.NameIdentifier, loginResult.Id.ToString())
                   };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                  HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.Now.AddDays(30),
                    }
                );
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultText = "Kullanıcı Adı veya Şifre Yanlış";
                 return View(param);
            }
            
        }
    }
}