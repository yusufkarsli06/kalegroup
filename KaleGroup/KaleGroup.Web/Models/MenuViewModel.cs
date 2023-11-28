namespace KaleGroup.Web.Models
{
    public class MenuViewModel
    {

        public MenuViewModel()
        {
            SubMenuViewModels = new List<SubMenuViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string EnName { get; set; }
        public string EnDescription { get; set; }

       public List<SubMenuViewModel> SubMenuViewModels { get; set; }
    }
}