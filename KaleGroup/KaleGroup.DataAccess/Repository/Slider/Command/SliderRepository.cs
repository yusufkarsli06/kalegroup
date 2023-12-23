using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.Slider.Interface;
using Microsoft.EntityFrameworkCore;
 

namespace KaleGroup.DataAccess.Repository.Slider.Command
{
    public class SliderRepository : Repository<Data.Entities.Slider>, ISliderRepository
    {
        public SliderRepository() : base(new BaseContext())
        {
        }
        public SliderRepository(BaseContext dbContext) : base(dbContext)
        {
        }


      

        public void PasiveSlider(int id)
        {
            var slider = _dbSet.Where(x => x.Id == id).FirstOrDefault();
            if (slider.IsActive == false)
            {
                slider.IsActive = true;
            }
            else
            {
                slider.IsActive = false;
            }

            _dbContext.Entry(slider).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

       
    }
}
