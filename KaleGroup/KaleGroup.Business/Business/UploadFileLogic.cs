using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Common.Helper;
using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Repository.Files.Interface;
using KaleGroup.DataAccess.Repository.User.Interface;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.Business.Business
{
    public class UploadFileLogic:IUploadFileLogic
    {
        private readonly IUploadFilesRepository _fileRepository;

        public UploadFileLogic(IUploadFilesRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public void AddFile(UploadFileDtos param)
        {
            UploadFiles uploadFiles = new UploadFiles();

            uploadFiles.FileName = param.FileName;
            uploadFiles.FilePath = param.FilePath;
            uploadFiles.FileUrl = param.FileUrl;
            uploadFiles.Description = param.Description;
            uploadFiles.IsActive = param.IsActive;

            _fileRepository.Insert(uploadFiles);

        }


        public UploadFileDtos GetUploadFileInfo(int fileId)
        {
            var uploadFiles = _fileRepository.GetById(fileId);

            UploadFileDtos uploadFilesDtos = new UploadFileDtos();
            uploadFilesDtos.Id = uploadFiles.Id;
            uploadFilesDtos.FileName = uploadFiles.FileName;
            uploadFilesDtos.FilePath = uploadFiles.FilePath;
            uploadFilesDtos.FileUrl = uploadFiles.FileUrl;
            uploadFilesDtos.Description = uploadFiles.Description;
            uploadFilesDtos.IsActive = uploadFiles.IsActive;
            return uploadFilesDtos;

        }
        public List<UploadFileDtos> GetUploadFileList()
        {
            List<UploadFileDtos> userDtos = new List<UploadFileDtos>();
            var file = _fileRepository.GetAll();
            foreach (var item in file)
            {
                UploadFileDtos uploadFilesDtos = new UploadFileDtos();
                uploadFilesDtos.Id = item.Id;
                uploadFilesDtos.FileName = item.FileName;
                uploadFilesDtos.FilePath = item.FilePath;
                uploadFilesDtos.FileUrl = item.FileUrl;
                uploadFilesDtos.Description = item.Description;
                uploadFilesDtos.IsActive = item.IsActive;

                userDtos.Add(uploadFilesDtos);
            }
            return userDtos;

        }

        public void PasiveFile(int fileId)
        {
            _fileRepository.PasiveUploadFile(fileId);
        }

        public void DeleteFile(int fileId)
        {
            var uploadFiles = _fileRepository.GetById(fileId);

            if (File.Exists(@"../KaleGroup.Web/wwwroot/"+uploadFiles.FilePath))
            {
                File.Delete(@"../KaleGroup.Web/wwwroot/"+uploadFiles.FilePath);
            }
            _fileRepository.Delete(fileId);
        }

        public void UpdateFile(UploadFileDtos param)
        {
            UploadFiles uploadFiles = new UploadFiles();

            uploadFiles.Id = param.Id;
            uploadFiles.FileName = param.FileName;
            uploadFiles.FilePath = param.FilePath;
            uploadFiles.FileUrl = param.FileUrl;
            uploadFiles.Description = param.Description;
            uploadFiles.IsActive = param.IsActive;

            _fileRepository.Update(uploadFiles);
        }

 
    }
}
