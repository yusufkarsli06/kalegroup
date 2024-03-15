namespace KaleGroup.Admin.Models
{
    public class SliderViewModel
    {
    
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string EnFilePath { get; set; }
        public bool IsActive { get; set; }
        public int PageId { get; set; }
        public int OrderNumber { get; set; }
        public string PageUrl { get; set; }
        public string EnPageUrl { get; set; }
        public IFormFile UploadFile { get; set; }
        public IFormFile EnUploadFile { get; set; }
        public bool IsTurnImage { get; set; }

 
    }
}