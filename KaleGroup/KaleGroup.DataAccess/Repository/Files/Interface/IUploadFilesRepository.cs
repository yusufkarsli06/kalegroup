
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.Files.Interface
{
    public interface IUploadFilesRepository : IRepository<UploadFiles>
    {
        void PasiveUploadFile(int fileId);
    }
}
