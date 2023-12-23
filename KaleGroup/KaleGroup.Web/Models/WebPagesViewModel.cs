namespace KaleGroup.Web.Models
{
    public class WebPagesViewModel
    {
        public WebPagesViewModel()
        {
            SubPagesViewModel = new List<SubPagesViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuId { get; set; }
        public string PageTopSubject { get; set; }
        public string PageTopDescription { get; set; }
        public string PageTopBackground { get; set; }
        public string PageTopImages { get; set; }
        public string PageDescription { get; set; }
        public bool IsActive { get; set; }
        public string PageUrl { get; set; }

        public string Keyword { get; set; }
        public string EnName { get; set; }
        public string EnPageTopSubject { get; set; }
        public string EnPageTopDescription { get; set; }
        public string EnPageTopBackground { get; set; }
        public string EnPageDescription { get; set; }
        public string EnPageUrl { get; set; }
        public bool IsNews { get; set; }
        public bool IsMenu { get; set; }
        public bool IsTopBody { get; set; }
        public bool IsButtomBody { get; set; }
        public string LastPageUrl { get; set; }
        public string LastPageName { get; set; }
        public List<SubPagesViewModel> SubPagesViewModel { get; set; }

    }
    public class SubPagesViewModel
    {
        public string PageTopSubject {get; set; }
        public string PageUrl { get; set; }
        public string PageImage { get; set; }

        public string EnPageTopSubject { get; set; }
        public string EnPageUrl { get; set; }
        public string CreatedAt { get; set; }
        public bool IsNews { get; set; }
    }
}