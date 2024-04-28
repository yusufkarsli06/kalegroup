using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
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
        private readonly ISettingsLogic _settingsLogic;
        private readonly IFooterMenusLogic _footerMenusLogic;
        // "tr"todo düzeltilmesi gerekiyor.;

        public HomeController(ILogger<HomeController> logger,
          IMenuLogic menuLogic, IWebPagesLogic webPagesLogic, IUserLogic userLogic, ISliderLogic sliderLogic
           , ISettingsLogic settingsLogic, IFooterMenusLogic footerMenusLogic)
        {
            _logger = logger;
            _webPagesLogic = webPagesLogic;
            _menuLogic = menuLogic;
            _userLogic = userLogic;
            _sliderLogic = sliderLogic;
            _settingsLogic = settingsLogic;
            _footerMenusLogic = footerMenusLogic;
        }

        public IActionResult Index()
        {
            SetFooterMenuSession();
            SetMenuSession();
            if(Request.Cookies["language"]==null)
                SetLanguage("tr"); 
 
            HomeViewModel vm = new HomeViewModel();           
            ViewBag.Language = Request.Cookies["language"];

            vm.SliderViewModel = GetSliderList(1);
            vm.TopBodyViewModel = GetTopBodyList();
            vm.ButtomBodyViewModel = GetButtomBodyList();
            vm.NewsBodyViewModel = GetNewBodyList();
            SetSettingsSession();

            return View(vm);
        }
 
        public IActionResult Pages(string pageUrl)
        {
            SetFooterMenuSession();
            SetMenuSession();
            try
            {
                string language = Request.Cookies["language"];
                if (pageUrl == "" || pageUrl==null)
                    return View("Error");

                WebPagesViewModel vm = new WebPagesViewModel();


                var pageResult = _webPagesLogic.GetWebPageByPageUrl(pageUrl);

                if (pageResult == null)
                    return View("Index");

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
                vm.IsNews = pageResult.IsNews;

                //todo bağlı olduğu sayfa bilgileri 

                var lastPageInfo = _webPagesLogic.GetWebPageByMenuId(pageResult.MenuId).Where(x => x.IsMenu).FirstOrDefault();
                if (lastPageInfo != null)
                {
                    vm.LastPageName = language == "tr" ? lastPageInfo.Name : lastPageInfo.EnName; ;
                    vm.LastPageUrl = language == "tr" ? lastPageInfo.PageUrl : lastPageInfo.EnPageUrl;

                }

                vm.IsMenu = pageResult.IsMenu;

                if ( pageResult.Id==46)
                {
                    var subPageResult = _webPagesLogic.GetWebPageByMenuId(pageResult.MenuId).Where(x => !x.IsMenu && x.IsNews);

                    List<SubPagesViewModel> subPageList = new List<SubPagesViewModel>();

                    foreach (var item in subPageResult)
                    {
                        SubPagesViewModel subPage = new SubPagesViewModel();

                        subPage.PageUrl = language == "tr" ? item.PageUrl : item.EnPageUrl;
                        subPage.PageImage = item.HomeImage==null || item.HomeImage=="" ?item.PageTopImages : item.HomeImage;
                        subPage.PageTopSubject = language == "tr" ? item.PageTopSubject : item.EnPageTopSubject;
                        subPage.CreatedAt = item.CreatedAt.ToShortDateString(); ;
                        subPage.IsNews = item.IsNews;
                        subPageList.Add(subPage);
                    }
                    vm.SubPagesViewModel = subPageList;

                }
                if (pageResult.IsMenu )
                {
                    var subPageResult = _webPagesLogic.GetWebPageByMenuId(pageResult.MenuId).Where(x => !x.IsMenu);

                    List<SubPagesViewModel> subPageList = new List<SubPagesViewModel>();

                    foreach (var item in subPageResult)
                    {
                        SubPagesViewModel subPage = new SubPagesViewModel();

                        subPage.PageUrl = language == "tr" ? item.PageUrl : item.EnPageUrl;
                        subPage.PageImage = item.HomeImage == null || item.HomeImage == "" ? item.PageTopImages : item.HomeImage;
                        subPage.PageTopSubject = language == "tr" ? item.PageTopSubject : item.EnPageTopSubject;
                        subPage.CreatedAt = item.CreatedAt.ToShortDateString(); ;
                        subPage.IsNews = item.IsNews;
                        subPageList.Add(subPage);
                    }
                    vm.SubPagesViewModel = subPageList;

                }
                ViewBag.Language = language;
                vm.SliderViewModel = GetSliderList(pageResult.Id);

                ViewBag.Keywords = language == "tr" ? pageResult.Keyword : pageResult.EnKeyword;
                 return View(vm);

            }
            catch (Exception)
            {

                return View("Index");
            }
        }
        public IActionResult SearchResult(string searchText)
        {
            SetFooterMenuSession();
            SetMenuSession();
            string language = Request.Cookies["language"];
            SearchViewModel vm = new SearchViewModel();
            vm.SearchText = searchText;

            List<SearchMenuViewModel> searchMenuListViewModel = new List<SearchMenuViewModel>();
            var mySessionObject = HttpContext.Session.GetString("menuModel");
            var menuModel = JsonConvert.DeserializeObject<List<MenuViewModel>>(mySessionObject);
            var pageResult = _webPagesLogic.GetWebSearchList(language, searchText);

            foreach (var item in menuModel)
            {
                var searchListViewModel = new List<SearchListViewModel>(); 

               
                var filteredResults = pageResult.Where(x => x.MenuId == item.Id).ToList();
                if (filteredResults.Count > 0)
                {
                    SearchMenuViewModel searchMenuViewModel = new SearchMenuViewModel();
                    searchMenuViewModel.MenuName = language == "tr" ? item.Name : item.EnName;

                    foreach (var resultItem in filteredResults)
                    {
                        SearchListViewModel searchListView = new SearchListViewModel();
                        searchListView.PageUrl = language == "tr" ? resultItem.PageUrl : resultItem.EnPageUrl;
                        searchListView.Name = language == "tr" ? resultItem.Name : resultItem.EnName;
                        searchListView.PageTopSubject = language == "tr" ? resultItem.PageTopSubject : resultItem.EnPageTopSubject;
                        searchListView.PageTopDescription = language == "tr" ? resultItem.PageTopDescription : resultItem.EnPageTopDescription;
                        searchListView.PageId = resultItem.Id;
                        searchListViewModel.Add(searchListView);
                    }

                    searchMenuViewModel.SearchListViewModel = searchListViewModel;
                    searchMenuListViewModel.Add(searchMenuViewModel);
                }
            }

            vm.SearchMenuViewModel = searchMenuListViewModel;
            ViewBag.Language = language;
            return View(vm);
        }
        public IActionResult FooterPages(string pageUrl)
        {
            SetFooterMenuSession();
            SetMenuSession();
            try
            {
                if (pageUrl == "" || pageUrl == null)
                    return View("Error");

                string language = Request.Cookies["language"];
                FooterPagesViewModel vm = new FooterPagesViewModel();

                var pageResult = _footerMenusLogic.GetFooterMenuPageByPageUrl(pageUrl);

                if (pageResult == null)
                    return View("Index");

                vm.PageTopSubject = language == "tr" ? pageResult.PageTopSubject : pageResult.EnPageTopSubject;
                vm.PageTopBackground = pageResult.PageTopBackground;
                vm.PageTopDescription = language == "tr" ? pageResult.PageTopDescription : pageResult.EnPageTopDescription;

                vm.PageDescription = language == "tr" ? pageResult.Description : pageResult.EnDescription;
                ViewBag.Language = language;
                return View(vm);

            }
            catch (Exception)
            {
                return View("Index");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            SetFooterMenuSession();
            SetMenuSession();
            ErrorViewModel vm = new ErrorViewModel();
            vm.RequestId = "101";
            vm.ShowRequestId = true;
           
            
            return View(vm);
        }
        public IActionResult SetLanguage(string language)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Append("language", language, cookie);
            return RedirectToAction("Index");
        }
        private List<SliderViewModel> GetSliderList(int pageId)
        {
            string language = Request.Cookies["language"];

            List<SliderViewModel> sliderList = new List<SliderViewModel>();
            var sliderResult = _sliderLogic.GetSliderByPageIdList(pageId);
            foreach (var item in sliderResult)
            {
                SliderViewModel slider = new SliderViewModel();

                slider.FilePath = language == "tr" ? item.FilePath : item.EnFilePath;
                slider.PageUrl = language == "tr" ? item.PageUrl : item.EnPageUrl;
                slider.IsTurnImage = item.IsTurnImage;
                sliderList.Add(slider);
            }


            return sliderList;

        }
        private List<TopBodyViewModel> GetTopBodyList()
        {
            string language = Request.Cookies["language"];
            List<TopBodyViewModel> topBodyList = new List<TopBodyViewModel>();

            var pageResult = _webPagesLogic.GetWebPageByDetailList(true, false, false);
            foreach (var item in pageResult)
            {
                TopBodyViewModel topBody = new TopBodyViewModel();

                topBody.FilePath = item.HomeImage!=null ?item.HomeImage: item.PageTopImages;
                topBody.Name = language == "tr" ? item.Name : item.EnName;

                topBody.Description = language == "tr" ? item.PageTopDescription : item.EnPageTopDescription;
                topBody.PageUrl = language == "tr" ? item.PageUrl : item.EnPageUrl;

                topBodyList.Add(topBody);
            }

            return topBodyList;

        }
        private List<ButtomBodyViewModel> GetButtomBodyList()
        {
            string language = Request.Cookies["language"];
            List<ButtomBodyViewModel> buttomBodyList = new List<ButtomBodyViewModel>();

            var pageResult = _webPagesLogic.GetWebPageByDetailList(false, true, false);
            foreach (var item in pageResult)
            {
                ButtomBodyViewModel buttomBody = new ButtomBodyViewModel();

                buttomBody.FilePath = item.HomeImage != null ? item.HomeImage : item.PageTopImages;
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

            var pageResult = _webPagesLogic.GetWebPageByDetailList(false, false, true).OrderByDescending(x => x.CreatedAt).Take(4);
            foreach (var item in pageResult)
            {
                NewsBodyViewModel newBody = new NewsBodyViewModel();

                newBody.FilePath = item.HomeImage!=null? item.HomeImage: item.PageTopImages;
                newBody.Name = language == "tr" ? item.Name : item.EnName;
                newBody.PageUrl = language == "tr" ? item.PageUrl : item.EnPageUrl;
                newBody.NewsDate = item.CreatedAt.ToShortDateString();

                newBodyList.Add(newBody);
            }
            return newBodyList;
        }


        private void SetSettingsSession()
        {
            var settings = _settingsLogic.GetSettingsList();
            List<SettingsViewModel> list = new List<SettingsViewModel>();

            foreach (var item in settings)
            {
                SettingsViewModel setting = new SettingsViewModel();

                setting.Key = item.SettingsKey;
                setting.Value = item.SettingsValue;
                list.Add(setting);
            }

            HttpContext.Session.SetString("settingsModel", JsonConvert.SerializeObject(list));
        }
        private void SetMenuSession()
        {
            //var mySessionObject = HttpContext.Session.GetString("menuModel");
            //if (mySessionObject == null)
            //{

                string language = Request.Cookies["language"];
                List<MenuViewModel> menuList = new List<MenuViewModel>();

                var menuResult = _menuLogic.GetMenuList().Where(x => x.IsActive).ToList();

                var webPageResult = _webPagesLogic.GetAllWebPagesList();

                foreach (var item in menuResult)
                {
                    List<WebPagesViewModel> webPageList = new List<WebPagesViewModel>();
                    MenuViewModel menu = new MenuViewModel();

                    menu.Name = language == "tr" ? item.Name : item.EnName;
                    menu.Id = item.Id;
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
                        webPage.Id = subItem.Id;

                        webPageList.Add(webPage);
                    }
                    menu.WebPagesViewModel = webPageList;
                    menuList.Add(menu);
                //}

                var str = JsonConvert.SerializeObject(menuList);
                HttpContext.Session.SetString("menuModel", str);
            }
        }
        private void SetFooterMenuSession()
        {
 
            var mySessionFooterObject = HttpContext.Session.GetString("footerModel");

            //if (mySessionFooterObject == null)
            //{

                string language = Request.Cookies["language"];
                List<FooterMenuView> footerMenuList = new List<FooterMenuView>();

                var resultFooterMenu = _footerMenusLogic.GetFooterMenuList().Where(x => x.IsActive);

                foreach (var item in resultFooterMenu)
                {
                    FooterMenuView footerMenu = new FooterMenuView();
                    if (language == "tr")
                    {
                        footerMenu.PageUrl = item.PageUrl != null ? item.PageUrl : item.FileUrl;
                        footerMenu.Name = item.PageName;
                        footerMenu.IsUrl = item.PageUrl != null ? true : false;
                    }
                    else
                    {
                        footerMenu.PageUrl = item.EnPageUrl != null ? item.EnPageUrl : item.EnFileUrl;
                        footerMenu.Name = item.EnPageName;
                        footerMenu.IsUrl = item.PageUrl != null ? true : false;
                    }
                    footerMenuList.Add(footerMenu);
                }

                var str = JsonConvert.SerializeObject(footerMenuList);
                HttpContext.Session.SetString("footerModel", str);
            //}
        }
    }
}