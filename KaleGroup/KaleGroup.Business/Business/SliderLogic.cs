using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.Slider.Interface;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using Nest;

namespace KaleGroup.Business.Business
{
    public class SliderLogic : ISliderLogic
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderLogic(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public List<SliderDtos> GetSliderByMenuIdList(int menuId)
        {
            List<SliderDtos> sliderList = new List<SliderDtos>();
            var sliderResult = _sliderRepository.GetAll().Where(x=>x.MenuId==menuId && x.IsActive).OrderBy(x=>x.OrderNumber);
            foreach (var item in sliderResult)
            {
                SliderDtos slider = new SliderDtos();

                slider.MenuId = item.MenuId;
                slider.FilePath = item.FilePath;
                slider.IsActive = item.IsActive;
                slider.Id = item.Id;
                slider.OrderNumber = item.OrderNumber;
                slider.PageUrl = item.PageUrl;
                slider.EnPageUrl = item.EnPageUrl;
                sliderList.Add(slider);

            }
            return sliderList;
        }
        public void PasiveSlider(int id)
        {
            _sliderRepository.PasiveSlider(id);
        }

        public void DeleteSlider(int menuId)
        {
            _sliderRepository.Delete(menuId);
        }
        public void AddSlider(SliderDtos param)
        {
            Slider slider = new Slider();

            slider.FilePath = param.FilePath;
            slider.MenuId = param.MenuId;         
            slider.OrderNumber = param.OrderNumber;         
            slider.IsActive = true;
            slider.PageUrl = param.PageUrl;
            slider.EnPageUrl = param.EnPageUrl;
            _sliderRepository.Insert(slider);
        }

        public void UpdateSlider(SliderDtos param)
        {
            Slider slider = new Slider();

            slider.Id = param.Id;
            slider.FilePath = param.FilePath;
            slider.MenuId = param.MenuId;          
            slider.IsActive = param.IsActive;
            slider.OrderNumber = param.OrderNumber;
            slider.PageUrl = param.PageUrl;
            slider.EnPageUrl = param.EnPageUrl;
            _sliderRepository.Update(slider);
        }

        public SliderDtos GetSlider(int id)
        {
            SliderDtos sliderDtos = new SliderDtos();

            var sliderResult = _sliderRepository.GetById(id);

            sliderResult.Id = sliderResult.Id;
            sliderDtos.FilePath  = sliderResult.FilePath;
            sliderDtos.MenuId = sliderResult.MenuId; 
            sliderDtos.IsActive = sliderResult.IsActive;
            sliderDtos.PageUrl = sliderResult.PageUrl;
            sliderDtos.EnPageUrl = sliderResult.EnPageUrl;
            sliderResult.OrderNumber = sliderResult.OrderNumber;

            return sliderDtos;

        }
    }
}



