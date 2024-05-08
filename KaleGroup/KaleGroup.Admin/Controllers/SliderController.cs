using KaleGroup.Admin.Models;
using KaleGroup.Business.Business;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaleGroup.Admin.Controllers
{
    [Authorize]
    public class SliderController : Controller
    {
        private readonly ISliderLogic _sliderLogic;
        private readonly IWebPagesLogic _pageLogic;
        public string filePath = @"../kalearge.canavardata.com/wwwroot/Uploads";

        public SliderController(ISliderLogic sliderLogic, IWebPagesLogic pageLogic)
        {
            _sliderLogic = sliderLogic;
            _pageLogic = pageLogic;
        }

        public IActionResult Index()
        {

            List<SliderViewModel> vm = new List<SliderViewModel>();

            var sliderResult = _sliderLogic.GetSliderList();

            foreach (var item in sliderResult)
            {
                SliderViewModel slider = new SliderViewModel();
                slider.PageUrl = item.PageUrl;
                slider.FilePath = item.FilePath;
                slider.EnFilePath = item.EnFilePath;
                slider.IsActive = item.IsActive;
                slider.OrderNumber = item.OrderNumber;
                slider.Id = item.Id;
                slider.IsTurnImage = item.IsTurnImage;
                vm.Add(slider);
            }
            return View(vm);
        }

        public IActionResult AddSlider()
        {
            AddSliderViewModel vm = new AddSliderViewModel();

            List<PageSelectionViewModel> pageList = new List<PageSelectionViewModel>();
            var pageListResult = _pageLogic.GetAllWebPagesList();

            foreach (var item in pageListResult)
            {
                PageSelectionViewModel page = new PageSelectionViewModel();

                page.PageName = item.Name;
                page.PageId = item.Id;
                pageList.Add(page);

            }
            vm.IsActive = true;
            vm.PageSelectionViewModel = pageList;

            return View(vm);
        }
        [HttpPost]
        public IActionResult AddSlider(AddSliderViewModel param)
        {

            if (param.UploadFile != null && param.EnUploadFile != null)
            {
                var extent = Path.GetExtension(param.UploadFile.FileName);

                var randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(filePath, randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.UploadFile.CopyTo(fileStream);

                var enExtent = Path.GetExtension(param.EnUploadFile.FileName);

                var enRandomName = ($"{Guid.NewGuid()}{enExtent}");

                string enSavePath = Path.Combine(filePath, enRandomName);

                using (FileStream fileStream = new FileStream((string)enSavePath, FileMode.Create))
                    param.EnUploadFile.CopyTo(fileStream);

                SliderDtos sliderDtos = new SliderDtos();

                sliderDtos.FilePath = "Uploads/"+randomName;
                sliderDtos.EnFilePath = "Uploads/" + enRandomName;
                sliderDtos.OrderNumber = param.OrderNumber;
                sliderDtos.IsActive = param.IsActive;
                sliderDtos.PageId = param.PageId;
                sliderDtos.PageUrl = param.PageUrl;
                sliderDtos.EnPageUrl = param.EnPageUrl;
                sliderDtos.IsTurnImage = param.IsTurnImage;

                _sliderLogic.AddSlider(sliderDtos);

            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateSlider(int id)
        {
            AddSliderViewModel vm = new AddSliderViewModel();
            var sliderResult = _sliderLogic.GetSlider(id);

            List<PageSelectionViewModel> pageList = new List<PageSelectionViewModel>();
            var pageListResult = _pageLogic.GetAllWebPagesList();

            foreach (var item in pageListResult)
            {
                PageSelectionViewModel page = new PageSelectionViewModel();

                page.PageName = item.Name;
                page.PageId = item.Id;
                pageList.Add(page);

            }
           
            vm.PageSelectionViewModel = pageList;
        
            vm.FilePath = sliderResult.FilePath;
            vm.EnFilePath = sliderResult.EnFilePath;
            vm.OrderNumber = sliderResult.OrderNumber;
            vm.IsActive = sliderResult.IsActive;
            vm.PageId = sliderResult.PageId;
            vm.PageUrl = sliderResult.PageUrl;
            vm.EnPageUrl = sliderResult.EnPageUrl;
            vm.IsTurnImage = sliderResult.IsTurnImage;

            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateSlider(AddSliderViewModel param)
        {
            if (param.UploadFile != null && param.EnUploadFile != null)
            {

                var extent = Path.GetExtension(param.UploadFile.FileName);

                var randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(filePath, randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.UploadFile.CopyTo(fileStream);


                var enExtent = Path.GetExtension(param.EnUploadFile.FileName);

                var enRandomName = ($"{Guid.NewGuid()}{enExtent}");

                string enSavePath = Path.Combine(filePath, enRandomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.EnUploadFile.CopyTo(fileStream);

                SliderDtos sliderDtos = new SliderDtos();
                sliderDtos.FilePath = "Uploads/" + randomName;
                sliderDtos.EnFilePath = "Uploads/" + enRandomName;
                sliderDtos.OrderNumber = param.OrderNumber;
                sliderDtos.IsActive = param.IsActive;
                sliderDtos.PageId = param.PageId;
                sliderDtos.PageUrl = param.PageUrl;
                sliderDtos.EnPageUrl = param.EnPageUrl;
                sliderDtos.Id = param.Id;
                sliderDtos.IsTurnImage = param.IsTurnImage;

                _sliderLogic.UpdateSlider(sliderDtos);
            }
            return RedirectToAction("Index");
        }



        public IActionResult PasiveSlider(int id)
        {
            _sliderLogic.PasiveSlider(id);

            return RedirectToAction("Index");
        }


        public IActionResult DeleteSlider(int id)
        {
            _sliderLogic.DeleteSlider(id);

            return RedirectToAction("Index");
        }
    }
}