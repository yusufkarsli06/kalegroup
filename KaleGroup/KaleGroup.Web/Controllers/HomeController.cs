using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nest;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

namespace KaleGroup.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuLogic _menuLogic;
        private readonly IUserLogic _userLogic;
        private readonly IWebPagesLogic _webPagesLogic;
        private readonly ISliderLogic _sliderLogic;

        public HomeController(ILogger<HomeController> logger,
          IMenuLogic menuLogic, IWebPagesLogic webPagesLogic, IUserLogic userLogic, ISliderLogic sliderLogic
            )
        {
            _logger = logger;
            _webPagesLogic = webPagesLogic;
            _menuLogic = menuLogic;
            _userLogic = userLogic;
            _sliderLogic = sliderLogic;
        }
        public IActionResult Login()
        {
            LoginViewModel vm = new LoginViewModel();
            return View(vm);
        }
        public IActionResult Index()
        {
            string language = Request.Cookies["language"];

            List<MenuViewModel> menuList = new List<MenuViewModel>();
            
            HomeViewModel vm = new HomeViewModel();


            var menuResult = _menuLogic.GetMenuList().Where(x => x.IsActive).ToList();

            var webPageResult = _webPagesLogic.GetAllWebPagesList();

            foreach (var item in menuResult)
            {


                List<WebPagesViewModel> webPageList = new List<WebPagesViewModel>();
                MenuViewModel menu = new MenuViewModel();

                menu.Name = language == "tr" ? item.Name : item.EnName;

                menu.PageUrl = language == "tr" ? webPageResult.Where(x => x.MenuId == item.Id && x.IsMenu).Select(x => x.PageUrl).FirstOrDefault() :
                    webPageResult.Where(x => x.MenuId == item.Id && x.IsMenu).Select(x => x.EnPageUrl).FirstOrDefault();

                var webPageListResult = webPageResult.Where(x => x.MenuId == item.Id && !x.IsMenu && x.IsSubMenu).ToList();

                foreach (var subItem in webPageListResult)
                {
                    WebPagesViewModel webPage = new WebPagesViewModel();
                    webPage.Name = language == "tr" ? subItem.Name : subItem.EnName; ;

                    webPage.MenuId = subItem.MenuId;
                    webPage.PageUrl = language == "tr" ? subItem.PageUrl : subItem.EnPageUrl;
                    webPage.PageTopSubject = language == "tr" ? subItem.PageTopSubject : subItem.EnPageTopSubject;
                    webPageList.Add(webPage);
                }
                menu.WebPagesViewModel = webPageList;
                menuList.Add(menu);
            }
            ViewBag.Language = language;
           
            var str = JsonConvert.SerializeObject(menuList);
            HttpContext.Session.SetString("menuModel", str);

            vm.SliderViewModel = GetSliderList(1);
            vm.TopBodyViewModel = GetTopBodyList();
            vm.ButtomBodyViewModel = GetButtomBodyList();
            vm.NewsBodyViewModel = GetNewBodyList();


            return View(vm);
        }

        public IActionResult Pages(string pageUrl)
        {
            string language = Request.Cookies["language"];
            WebPagesViewModel vm = new WebPagesViewModel();


            var pageResult = _webPagesLogic.GetWebPageByPageUrl(pageUrl);


            vm.Id = pageResult.Id;
            vm.Name = language == "tr" ? pageResult.Name : pageResult.EnName;
            vm.MenuId = pageResult.MenuId;

            vm.PageTopSubject = language == "tr" ? pageResult.PageTopSubject : pageResult.EnPageTopSubject;
            vm.PageTopBackground = pageResult.PageTopBackground;
            vm.PageTopDescription = language == "tr" ? pageResult.PageTopDescription : pageResult.EnPageTopDescription;

            vm.PageTopImages = pageResult.PageTopImages;
            vm.PageDescription = language == "tr" ? pageResult.PageDescription : pageResult.EnPageDescription;
            vm.PageUrl = language == "tr" ? pageResult.PageUrl : pageResult.EnPageUrl;
            //todo anahtar kelime ingilizce 
            vm.Keyword = pageResult.Keyword;

            //todo bağlı olduğu sayfa bilgileri 

            var lastPageInfo = _webPagesLogic.GetWebPageByMenuId(pageResult.MenuId).Where(x=>x.IsMenu).FirstOrDefault();
           if(lastPageInfo!= null)
            {
                vm.LastPageName = language == "tr" ? lastPageInfo.Name : lastPageInfo.EnName; ;
                vm.LastPageUrl = language == "tr" ? lastPageInfo.PageUrl : lastPageInfo.EnPageUrl;

            }

            vm.IsMenu = pageResult.IsMenu;

            if (pageResult.IsMenu)
            {
                var subPageResult = _webPagesLogic.GetWebPageByMenuId(pageResult.MenuId).Where(x=>!x.IsMenu);

                List<SubPagesViewModel> subPageList = new List<SubPagesViewModel>();

                foreach (var item in subPageResult)
                {
                    SubPagesViewModel subPage = new SubPagesViewModel();

                    subPage.PageUrl = language == "tr" ? item.PageUrl : item.EnPageUrl;
                    subPage.PageImage = item.PageTopImages;
                    subPage.PageTopSubject = language == "tr" ? item.PageTopSubject : item.EnPageTopSubject;
                    subPage.CreatedAt = item.CreatedAt.ToString("dd.MMMM.yyyy");
                    subPage.IsNews = item.IsNews;
                    subPageList.Add(subPage);
                }
                vm.SubPagesViewModel = subPageList;

            }
            ViewBag.Language = language;
            return View(vm);
        }

        public IActionResult SearchResult(string searchText)
        {
            string language = Request.Cookies["language"];
            List<SearchListViewModel> searchList = new List<SearchListViewModel>();
            List<SearchMenuViewModel> searchMenuListViewModel = new List<SearchMenuViewModel>();
            SearchViewModel vm = new SearchViewModel();


            var pageResult = _webPagesLogic.GetWebSearchList(language,searchText);

            var mySessionObject =  HttpContext.Session.GetString("menuModel");
            var menuModel = JsonConvert.DeserializeObject<List<MenuViewModel>>(mySessionObject);

            foreach (var item in pageResult)
            {
                SearchMenuViewModel searchMenuViewModel = new SearchMenuViewModel();

                var menuNames = menuModel.Where(x => x.Id == item.MenuId);
                
                string menuName = menuNames.Select(x => x.Name).FirstOrDefault();
                string menuEnName = menuNames.Select(x => x.EnName).FirstOrDefault();

                searchMenuViewModel.MenuName = language == "tr" ? menuName : menuEnName;
                foreach (var itemList in pageResult.Where(x=>x.MenuId==item.MenuId))
                {
                    SearchListViewModel search = new SearchListViewModel();

                    search.Name = language == "tr" ? itemList.Name : itemList.EnName;

                    search.PageTopSubject = language == "tr" ? itemList.PageTopSubject : itemList.EnPageTopSubject;
                    search.PageTopDescription = language == "tr" ? itemList.PageTopDescription : itemList.EnPageTopDescription;

                    search.PageUrl = language == "tr" ? itemList.PageUrl : itemList.EnPageUrl;

                    searchList.Add(search);
                }
                searchMenuListViewModel.Add(searchMenuViewModel);
                searchMenuViewModel.SearchListViewModel = searchList;

            }

            vm.SearchText = searchText;
            vm.SearchMenuViewModel = searchMenuListViewModel;
            ViewBag.Language = language;
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
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Append("language", language, cookie);
            return RedirectToAction("Index");
        }
        private List<SliderViewModel> GetSliderList(int menuId)
        {
            List<SliderViewModel> sliderList = new List<SliderViewModel>();
           var sliderResult = _sliderLogic.GetSliderByMenuIdList(menuId);
            foreach (var item in sliderResult)
            {
                SliderViewModel slider = new SliderViewModel();

                slider.FilePath = item.FilePath;
                sliderList.Add(slider);
            }


            return sliderList;

        }

        private List<TopBodyViewModel> GetTopBodyList()
        {
            string language = Request.Cookies["language"];

            List<TopBodyViewModel> topBodyList = new List<TopBodyViewModel>();

            var pageResult = _webPagesLogic.GetWebPageByDetailList(true,false,false);
            foreach (var item in pageResult)
            {
                TopBodyViewModel topBody = new TopBodyViewModel();

                topBody.FilePath = item.PageTopImages;
                topBody.Name = language == "tr" ? item.Name : item.EnName;

                topBody.Description =language == "tr" ? item.PageTopDescription : item.EnPageTopDescription;
                topBody.PageUrl =language == "tr" ? item.PageUrl : item.EnPageUrl;
                
                topBodyList.Add(topBody);
            }


            return topBodyList;

        }
        private List<ButtomBodyViewModel> GetButtomBodyList()
        {
            string language = Request.Cookies["language"];

            List<ButtomBodyViewModel> buttomBodyList = new List<ButtomBodyViewModel>();

            var pageResult = _webPagesLogic.GetWebPageByDetailList(false,true,false);
            foreach (var item in pageResult)
            {
                ButtomBodyViewModel buttomBody = new ButtomBodyViewModel();

                buttomBody.FilePath = item.PageTopImages;
                buttomBody.Name = language == "tr" ? item.Name : item.EnName;
                buttomBody.PageUrl = language == "tr" ? item.PageUrl : item.EnPageUrl;
 
                buttomBodyList.Add(buttomBody);
            }


            return buttomBodyList;

        } 
        
        private List<NewsBodyViewModel> GetNewBodyList()
        {
            string language = Request.Cookies["language"];

            List<NewsBodyViewModel> newBodyList = new List<NewsBodyViewModel>();

            var pageResult = _webPagesLogic.GetWebPageByDetailList(false,false,true);
            foreach (var item in pageResult)
            {
                NewsBodyViewModel newBody = new NewsBodyViewModel();

                newBody.FilePath = item.PageTopImages;
                newBody.Name = language == "tr" ? item.Name : item.EnName;
                newBody.PageUrl = language == "tr" ? item.PageUrl : item.EnPageUrl;
                newBody.NewsDate =  item.CreatedAt.ToString("dd.MMMM.yyyy");
 
                newBodyList.Add(newBody);
            }

            return newBodyList;

        }
    }
}