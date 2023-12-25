namespace KaleGroup.Web.Models
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            SearchMenuViewModel = new List<SearchMenuViewModel>();
    
        }

        public List<SearchMenuViewModel> SearchMenuViewModel { get; set; }

        public string SearchText { get; set; } 

    }
    public class SearchMenuViewModel
    {
        public SearchMenuViewModel()
        {
            SearchListViewModel = new List<SearchListViewModel>();

        }
        public string MenuName { get; set; }
        public List<SearchListViewModel> SearchListViewModel { get; set; }


    }
    public class SearchListViewModel
    {
        public string Name { get; set; }
        public string PageTopSubject { get; set; }
        public string PageTopDescription { get; set; }
        public string PageUrl { get; set; }

    }

}