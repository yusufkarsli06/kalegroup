using KaleGroup.DataAccess.Abstract;

namespace KaleGroup.DataAccess.Repository.Slider.Interface
{
    public interface ISliderRepository : IRepository<Data.Entities.Slider>
    { 
        void PasiveSlider(int id); 
    }
}
