using KaleGroup.Data.Abstract;

namespace KaleGroup.Data.Entities
{
    public class Slider : ModelBase
    {
        public string FilePath { get; set; }
        public string EnFilePath { get; set; }
        public string PageUrl { get; set; }
        public string EnPageUrl { get; set; }
        public bool IsActive { get; set; }
        public int PageId { get; set; }
        public int OrderNumber { get; set; }
        public bool IsTurnImage { get; set; }


    }
}





