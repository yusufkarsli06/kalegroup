using KaleGroup.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Dto
{
    public class UploadFileDtos : ModelBaseDto
    {
      
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
         
    }
}

 



 











