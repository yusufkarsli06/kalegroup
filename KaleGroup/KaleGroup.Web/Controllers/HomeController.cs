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
using RestSharp;
 
namespace KaleGroup.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuLogic _menuLogic;
        private readonly IUserLogic _userLogic;
        private readonly IWebPagesLogic _webPagesLogic;

        public HomeController(ILogger<HomeController> logger,
          IMenuLogic menuLogic, IWebPagesLogic webPagesLogic, IUserLogic userLogic
            )
        {
            _logger = logger;
            _webPagesLogic = webPagesLogic;
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

            var webPageResult = _webPagesLogic.GetAllWebPagesList();

            foreach (var item in menuResult)
            {


                List<WebPagesViewModel> webPageList = new List<WebPagesViewModel>();
                MenuViewModel menu = new MenuViewModel();
                menu.Name = item.Name;
                menu.EnName = item.EnName;
                menu.PageUrl = webPageResult.Where(x => x.MenuId == item.Id && x.IsMenu).Select(x => x.PageUrl).FirstOrDefault();

                var webPageListResult = webPageResult.Where(x => x.MenuId == item.Id && !x.IsMenu).ToList();

                foreach (var subItem in webPageListResult)
                {
                    WebPagesViewModel webPage = new WebPagesViewModel();
                    webPage.Name = subItem.Name;
                    webPage.EnName = subItem.EnName;
                    webPage.MenuId = subItem.MenuId;
                    webPage.PageUrl = subItem.PageUrl;
                    webPage.PageTopSubject = subItem.PageTopSubject;
                    webPageList.Add(webPage);
                }
                menu.WebPagesViewModel = webPageList;
                vm.Add(menu);
            }

            return View(vm);
        }
        
        public IActionResult Pages(string pageUrl)
        {
            WebPagesViewModel vm = new WebPagesViewModel();


            var pageResult = _webPagesLogic.GetWebPageByPageUrl(pageUrl);
             
 
            vm.Id = pageResult.Id;
            vm.Name = pageResult.Name;
            vm.MenuId = pageResult.MenuId;
            vm.EnName = pageResult.EnName;
            vm.PageTopSubject= pageResult.PageTopSubject;
            vm.PageTopBackground = pageResult.PageTopBackground;
            vm.PageTopDescription = pageResult.PageTopDescription;
            vm.EnPageTopDescription = pageResult.EnPageTopDescription;
            vm.PageTopImages = pageResult.PageTopImages;
            vm.PageDescription = pageResult.PageDescription;
            vm.PageUrl = pageResult.PageUrl;
            vm.Keyword = pageResult.Keyword;
           
            vm.EnPageTopSubject = pageResult.EnPageTopSubject;
            vm.EnPageTopSubject = pageResult.EnPageTopSubject;
            vm.EnPageTopDescription = pageResult.EnPageTopDescription;
            vm.EnPageTopBackground = pageResult.EnPageTopBackground;
            vm.EnPageDescription = pageResult.EnPageDescription;
            vm.EnPageUrl = pageResult.EnPageUrl;
            vm.LastPageName ="İnsan Kaynakları";
            vm.LastPageUrl = "insan_kaynaklari";
            vm.IsMenu = pageResult.IsMenu;

            if (pageResult.IsMenu)
            {
                var subPageResult = _webPagesLogic.GetWebPageByMenuId(pageResult.MenuId);

                List<SubPagesViewModel> subPageList = new List<SubPagesViewModel>();

                foreach (var item in subPageResult)
                {
                    SubPagesViewModel subPage = new SubPagesViewModel();

                    subPage.PageUrl = item.PageUrl;
                    subPage.EnPageUrl = item.EnPageUrl;
                    subPage.EnPageTopSubject = subPage.EnPageTopSubject;
                    subPage.PageImage = item.PageTopImages;
                    subPage.PageTopSubject = item.PageTopSubject;
                    subPageList.Add(subPage);
                }
                vm.SubPagesViewModel = subPageList;

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


        public IActionResult SetLanguage(string language)
        {
             Cookie Cookie = new  Cookie("weblanguage");

            
          
            
            Cookie["language"] = language;
            Cookie.Expires = DateTime.Now.AddMonths(1);
             Response.Cookies.Add(Cookie);
            return RedirectToAction("Index");


        }
    }
}