namespace KaleGroup.Admin.Models
{
    public class AddSubMenuViewModel
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string EnName { get; set; }
        public string EnDescription { get; set; }
        public int MenuId { get; set; }

     }
}