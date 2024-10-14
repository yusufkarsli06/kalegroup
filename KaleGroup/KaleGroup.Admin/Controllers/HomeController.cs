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
using Microsoft.Extensions.Caching.Memory;

namespace KaleGroup.Admin.Controllers
{
    [XssProtectionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserLogic _userLogic;
        private readonly ICaptchaHelper _captchaHelper;
        private const int MaxFailedAttempts = 3;
        private readonly IMemoryCache _cache;

        public HomeController(IMemoryCache cache, ILogger<HomeController> logger, IUserLogic userLogic, ICaptchaHelper captchaHelper)
        {
            _logger = logger;
            _userLogic = userLogic;
            _captchaHelper = captchaHelper;
            _cache = cache;
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

            var model = new LoginViewModel();

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
            string userIp = HttpContext.Connection.RemoteIpAddress.ToString();
            int failedAttempts;


            var loginResult = _userLogic.AuthenticateUser(param.Username, param.Password);

            if (loginResult != null)
            {
                var captchaCodeCache = _cache.Get("CaptchaCode").ToString();
                if (param.CaptchaCode != null)
                {
                    if (param.CaptchaCode != captchaCodeCache)
                    {
                        ModelState.AddModelError(string.Empty, "Captcha doğrulaması başarısız.");
                        param.ShowCaptcha = true;

                        var captchaCode = _captchaHelper.GenerateRandomCode();
                        _cache.Set("CaptchaCode", captchaCode, TimeSpan.FromMinutes(15));
                        ViewBag.CaptchaImage = Convert.ToBase64String(_captchaHelper.GenerateCaptchaImage(captchaCode));

                        return View(param);
                    }
                }
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

                _cache.Set(userIp, 0, TimeSpan.FromMinutes(15));

                return RedirectToAction("Index");
            }
            else
            {


                // Eğer cache'de bu IP'ye dair bir kayıt varsa onu al, yoksa 0 başlat.
                if (!_cache.TryGetValue(userIp, out failedAttempts))
                {
                    failedAttempts = 0;
                }

                failedAttempts++;

                // Yeni değer ile IP adresini cache'de 15 dakika sakla
                _cache.Set(userIp, failedAttempts, TimeSpan.FromMinutes(15));

                if (failedAttempts >= 3)
                {
                    var captchaCodeCache = _cache.Get("CaptchaCode");

                    if (param.CaptchaCode == null || param.CaptchaCode != captchaCodeCache)
                    {
                        ModelState.AddModelError(string.Empty, "Captcha doğrulaması başarısız.");
                        param.ShowCaptcha = true;

                        var captchaCode = _captchaHelper.GenerateRandomCode();
                        _cache.Set("CaptchaCode", captchaCode, TimeSpan.FromMinutes(15));
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