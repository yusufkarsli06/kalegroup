namespace KaleGroup.Web.Models
{
    public class SubMenuViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MenuId { get; set; }
        public bool IsActive { get; set; }
        public string EnName { get; set; }
        public string EnDescription { get; set; }
        List<SubMenuViewModel> subMenuViewModels { get; set; }
    }
}