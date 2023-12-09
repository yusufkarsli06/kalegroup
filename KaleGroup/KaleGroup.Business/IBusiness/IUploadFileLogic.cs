using KaleGroup.Business.Dto;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.IBusiness
{
    public interface IUploadFileLogic
    {
        void AddFile(UploadFileDtos uploadFile);

        UploadFileDtos GetUploadFileInfo(int fileId);
        List<UploadFileDtos> GetUploadFileList();
        void PasiveFile(int fileId);
        void DeleteFile(int fileId);
        void UpdateFile(UploadFileDtos param);
         
    }
}
