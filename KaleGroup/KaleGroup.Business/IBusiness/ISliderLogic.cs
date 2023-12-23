
using KaleGroup.Business.Dto;
using KaleGroup.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.IBusiness
{
    public interface ISliderLogic
    {
        List<SliderDtos> GetSliderByMenuIdList(int menuId);
        void PasiveSlider(int id);
        void DeleteSlider(int menuId);
        void AddSlider(SliderDtos param);
        void UpdateSlider(SliderDtos param);
        SliderDtos GetSlider(int id);
      
    }
}
