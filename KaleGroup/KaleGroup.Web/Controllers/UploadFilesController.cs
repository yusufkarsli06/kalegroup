using KaleGroup.Business.Business;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using KaleGroup.Web.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;

namespace KaleGroup.Web.Controllers
{
    public class UploadFileController : Controller
    {
        private readonly IUploadFileLogic _uploadFileLogic;
        public UploadFileController(IUploadFileLogic uploadFileLogic)
        {
            _uploadFileLogic = uploadFileLogic;
        }

        public IActionResult Index()
        {

            List<AddFileViewModel> vm = new List<AddFileViewModel>();

            var fileResult = _uploadFileLogic.GetUploadFileList();

            foreach (var item in fileResult)
            {
                AddFileViewModel file = new AddFileViewModel();
                file.Name = item.FileName;
                file.Description = item.Description;
                file.IsActive = item.IsActive;
                file.Id = item.Id;

                vm.Add(file);
            }
            return View(vm);
        }

        public IActionResult AddFile()
        {
            AddFileViewModel vm = new AddFileViewModel();

            return View(vm);
        }
        [HttpPost]
        public IActionResult AddFile(AddFileViewModel param)
        {

        
            UploadFileDtos fileDtos = new UploadFileDtos();
            fileDtos.FileName = fileDtos.FileName;
            fileDtos.FilePath = fileDtos.FilePath;
            fileDtos.FileUrl = fileDtos.FileUrl;
            fileDtos.Description = fileDtos.Description;
            fileDtos.IsActive = fileDtos.IsActive;        


            _uploadFileLogic.AddFile(fileDtos);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateFile(int fileId)
        {
            AddFileViewModel vm = new AddFileViewModel();
            var fileDtos = _uploadFileLogic.GetUploadFileInfo(fileId);

            vm.Name = fileDtos.FileName;
            vm.FilePath = fileDtos.FilePath;
            vm.FileUrl = fileDtos.FileUrl;
            vm.Description = fileDtos.Description;
            vm.IsActive = fileDtos.IsActive;
            vm.Id = fileDtos.Id;


            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateFile(AddFileViewModel param)
        {
            UploadFileDtos fileDtos = new UploadFileDtos();
            fileDtos.FileName = fileDtos.FileName;
            fileDtos.FilePath = fileDtos.FilePath;
            fileDtos.FileUrl = fileDtos.FileUrl;
            fileDtos.Description = fileDtos.Description;
            fileDtos.IsActive = fileDtos.IsActive;
            fileDtos.Id = fileDtos.Id;


            _uploadFileLogic.UpdateFile(fileDtos);
            return RedirectToAction("Index");
        }

    }
}