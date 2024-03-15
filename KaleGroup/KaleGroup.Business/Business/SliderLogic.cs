using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.Slider.Interface;

namespace KaleGroup.Business.Business
{
    public class SliderLogic : ISliderLogic
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderLogic(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public List<SliderDtos> GetSliderByPageIdList(int pageId)
        {
            List<SliderDtos> sliderList = new List<SliderDtos>();
            var sliderResult = _sliderRepository.GetAll().Where(x=>x.PageId == pageId && x.IsActive).OrderBy(x=>x.OrderNumber);
            foreach (var item in sliderResult)
            {
                SliderDtos slider = new SliderDtos();

                slider.PageId = item.PageId;
                slider.FilePath = item.FilePath;
                slider.EnFilePath = item.EnFilePath;
                slider.IsActive = item.IsActive;
                slider.Id = item.Id;
                slider.OrderNumber = item.OrderNumber;
                slider.PageUrl = item.PageUrl;
                slider.EnPageUrl = item.EnPageUrl;
                slider.IsTurnImage = item.IsTurnImage;
                sliderList.Add(slider);

            }
            return sliderList;
        }
        public List<SliderDtos> GetSliderList()
        {
            List<SliderDtos> sliderList = new List<SliderDtos>();
            var sliderResult = _sliderRepository.GetAll().OrderBy(x => x.OrderNumber);
            foreach (var item in sliderResult)
            {
                SliderDtos slider = new SliderDtos();

                slider.PageId = item.PageId;
                slider.FilePath = item.FilePath;
                slider.EnFilePath = item.EnFilePath;
                slider.IsActive = item.IsActive;
                slider.Id = item.Id;
                slider.OrderNumber = item.OrderNumber;
                slider.PageUrl = item.PageUrl;
                slider.EnPageUrl = item.EnPageUrl;
                slider.IsTurnImage = item.IsTurnImage;
                sliderList.Add(slider);

            }
            return sliderList;
        }
        public void PasiveSlider(int id)
        {
            _sliderRepository.PasiveSlider(id);
        }

        public void DeleteSlider(int id)
        {
            var sliderResult = _sliderRepository.GetById(id);

            _sliderRepository.Delete(id);
            
            if (File.Exists(@"../KaleGroup.Web/wwwroot/"+sliderResult.FilePath))
            {
                File.Delete(@"../KaleGroup.Web/wwwroot/"+sliderResult.FilePath);
            }
            
            if (File.Exists(@"../KaleGroup.Web/wwwroot/"+sliderResult.EnFilePath))
            {
                File.Delete(@"../KaleGroup.Web/wwwroot/"+sliderResult.EnFilePath);
            }
        }
        public void AddSlider(SliderDtos param)
        {
            Slider slider = new Slider();

            slider.FilePath = param.FilePath;
            slider.EnFilePath = param.EnFilePath;
            slider.PageId = param.PageId;         
            slider.OrderNumber = param.OrderNumber;         
            slider.IsActive = true;
            slider.PageUrl = param.PageUrl;
            slider.EnPageUrl = param.EnPageUrl;
            slider.IsTurnImage = param.IsTurnImage;
            _sliderRepository.Insert(slider);
        }

        public void UpdateSlider(SliderDtos param)
        {
            Slider slider = new Slider();

            slider.Id = param.Id;
            slider.FilePath = param.FilePath;
            slider.EnFilePath = param.EnFilePath;
            slider.PageId = param.PageId;          
            slider.IsActive = param.IsActive;
            slider.OrderNumber = param.OrderNumber;
            slider.PageUrl = param.PageUrl;
            slider.EnPageUrl = param.EnPageUrl;
            slider.IsTurnImage = param.IsTurnImage;
            _sliderRepository.Update(slider);
        }

        public SliderDtos GetSlider(int id)
        {
            SliderDtos sliderDtos = new SliderDtos();

            var sliderResult = _sliderRepository.GetById(id);

            sliderResult.Id = sliderResult.Id;
            sliderDtos.FilePath  = sliderResult.FilePath;
            sliderDtos.EnFilePath  = sliderResult.EnFilePath;
            sliderDtos.PageId = sliderResult.PageId; 
            sliderDtos.IsActive = sliderResult.IsActive;
            sliderDtos.PageUrl = sliderResult.PageUrl;
            sliderDtos.EnPageUrl = sliderResult.EnPageUrl;
            sliderDtos.OrderNumber = sliderResult.OrderNumber;
            sliderDtos.IsTurnImage = sliderResult.IsTurnImage;

            return sliderDtos;

        }
    }
}



