namespace KaleGroup.Web.Models
{
    public class MenuViewModel
    {

        public MenuViewModel()
        {
            WebPagesViewModel = new List<WebPagesViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string EnName { get; set; }
        public string EnDescription { get; set; }
        public string PageUrl { get; set; }

       public List<WebPagesViewModel> WebPagesViewModel  { get; set; }
     }
}