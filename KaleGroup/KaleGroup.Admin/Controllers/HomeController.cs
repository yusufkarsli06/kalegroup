using KaleGroup.Admin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using KaleGroup.Business.IBusiness;
using Microsoft.AspNetCore.Authorization;
using NPOI.SS.Formula.Functions;
using KaleGroup.Common.Helper;
using KaleArge.Admin.Filter;

namespace KaleGroup.Admin.Controllers
{
    [XssProtectionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserLogic _userLogic;
        private readonly ICaptchaHelper _captchaHelper;
        private const int MaxFailedAttempts = 3;
        public HomeController(ILogger<HomeController> logger, IUserLogic userLogic, ICaptchaHelper captchaHelper)
        {
            _logger = logger;
            _userLogic = userLogic;
            _captchaHelper = captchaHelper;
        }
        [Authorize]
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

        public IActionResult Login()
        {
            int failedAttempts = HttpContext.Session.GetInt32("FailedAttempts") ?? 0;

            var model = new LoginViewModel();
            model.ShowCaptcha = failedAttempts >= MaxFailedAttempts;

            if (model.ShowCaptcha)
            {
                string captchaCode = _captchaHelper.GenerateRandomCode();
                HttpContext.Session.SetString("CaptchaCode", captchaCode);
                ViewBag.CaptchaImage = Convert.ToBase64String(_captchaHelper.GenerateCaptchaImage(captchaCode));
            }

            return View(model);
         
        }
        public async Task<IActionResult> LogOut()
        {
  
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

             return RedirectToAction("Login", "Home");
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
                            new Claim("EndDate",  DateTime.MinValue.AddMinutes(15).ToString()),
                            new Claim(ClaimTypes.NameIdentifier, loginResult.Id.ToString())
                   };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(identity),
                  new AuthenticationProperties
                  {
                      IsPersistent = true,
                      ExpiresUtc = DateTimeOffset.Now.AddMinutes(15),
                  }
              );
                HttpContext.Session.SetInt32("FailedAttempts", 0);
                return RedirectToAction("Index");
            }
            else
            {          
                int failedAttempts = HttpContext.Session.GetInt32("FailedAttempts") ?? 0;
                failedAttempts++;
                HttpContext.Session.SetInt32("FailedAttempts", failedAttempts);

                // Captcha doğrulaması gerekiyorsa kontrol et
                if (failedAttempts >= MaxFailedAttempts)
                {
                    var captchaCode = HttpContext.Session.GetString("CaptchaCode");

                    if (param.CaptchaCode == null || param.CaptchaCode != captchaCode)
                    {
                        ModelState.AddModelError(string.Empty, "Captcha doğrulaması başarısız.");
                        param.ShowCaptcha = true;

                        
                        captchaCode = _captchaHelper.GenerateRandomCode();
                        HttpContext.Session.SetString("CaptchaCode", captchaCode);
                        ViewBag.CaptchaImage = Convert.ToBase64String(_captchaHelper.GenerateCaptchaImage(captchaCode));

                        return View(param);
                    }
                }
                ViewBag.ResultText = "Kullanıcı Adı veya Şifre Yanlış";
                return View(param);
            }

        }

    }
}