namespace KaleGroup.Web.Models
{
    public class HomeViewModel
    {

        public HomeViewModel()
        {
            SliderViewModel = new List<SliderViewModel>();
             TopBodyViewModel = new List<TopBodyViewModel>();
            ButtomBodyViewModel = new List<ButtomBodyViewModel>();
            NewsBodyViewModel = new List<NewsBodyViewModel>();
        }

        
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    

       public List<SliderViewModel> SliderViewModel { get; set; }
        public List<TopBodyViewModel> TopBodyViewModel { get; set; }
       public List<ButtomBodyViewModel> ButtomBodyViewModel { get; set; }
       public List<NewsBodyViewModel> NewsBodyViewModel { get; set; }
     }
    public class SliderViewModel
    {
        public string FilePath { get; set; }

    }
 
    public class AcordionDetailViewModel
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string PageUrl { get; set; }

    }

    public class TopBodyViewModel
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PageUrl { get; set; }
        public string LastPageUrl { get; set; }

    }

    public class ButtomBodyViewModel
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PageUrl { get; set; }

    }  
    public class NewsBodyViewModel
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string NewsDate { get; set; }
        public string PageUrl { get; set; }

    }
}