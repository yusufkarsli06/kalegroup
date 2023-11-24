
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.Files.Interface
{
    public interface IFilesRepository
    {
        bool AddFiles(KaleGroup.Data.Entities.Files files);
        List<KaleGroup.Data.Entities.Files> GetFilesList();
        bool UpdateFiles(KaleGroup.Data.Entities.Files files);
        bool DeleteFiles(int fileId);
        KaleGroup.Data.Entities.Files GetFiles(int Id);

    }
}
