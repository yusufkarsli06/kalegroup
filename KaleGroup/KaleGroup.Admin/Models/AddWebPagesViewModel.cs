namespace KaleGroup.Admin.Models
{
    public class AddWebPagesViewModel
    {
        public AddWebPagesViewModel()
        {
            MenuSelectionViewModel = new List<MenuSelectionViewModel>();
          
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuId { get; set; }
        public string PageTopSubject { get; set; }
        public string PageTopDescription { get; set; }
        public string PageTopBackground { get; set; }
        public string? PageTopImages { get; set; }
        public string? HomeImage { get; set; }
        public IFormFile PageTopImagesFiles { get; set; }
        public string PageDescription { get; set; }
        public bool IsActive { get; set; }
        public string PageUrl { get; set; }

        public string Keyword { get; set; }
        public string EnKeyword { get; set; }
        public string EnName { get; set; }
        public string EnPageTopSubject { get; set; }
        public string EnPageTopDescription { get; set; }
        public string EnPageTopBackground { get; set; }
        public string EnPageDescription { get; set; }
        public string EnPageUrl { get; set; }
        public bool IsNews { get; set; }
        public bool IsMenu { get; set; }
        public bool IsSubMenu { get; set; }
        public bool IsTopBody { get; set; }
        public bool IsButtomBody { get; set; }
        public string LastPageUrl { get; set; }
        public string LastPageName { get; set; }
        public bool IsSlider { get; set; }
        public List<MenuSelectionViewModel> MenuSelectionViewModel { get; set; }
        public IFormFile? UploadFile { get; set; }
        public IFormFile? HomeImageUploadFile { get; set; }



    }

}