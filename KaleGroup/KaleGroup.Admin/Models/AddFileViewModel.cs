namespace KaleGroup.Admin.Models
{
    public class AddFileViewModel
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string FilePath { get; set; }
        public string FileUrl { get; set; }
        public IFormFile UploadFile { get; set; }
      

    }
}