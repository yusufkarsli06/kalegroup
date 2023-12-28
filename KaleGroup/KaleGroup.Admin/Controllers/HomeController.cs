using KaleGroup.Admin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using KaleGroup.Business.IBusiness;

namespace KaleGroup.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserLogic _userLogic;
        public HomeController(ILogger<HomeController> logger, IUserLogic userLogic)
        {
            _logger = logger;
            _userLogic = userLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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

            if (loginResult != null)
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