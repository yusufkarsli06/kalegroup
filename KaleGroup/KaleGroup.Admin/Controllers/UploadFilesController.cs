using KaleGroup.Admin.Models;
using KaleGroup.Business.Dto;
using KaleGroup.Business.IBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaleGroup.Admin.Controllers
{
    [Authorize]
    public class UploadFilesController : Controller
    {
        private readonly IUploadFileLogic _uploadFileLogic;
        public string filePath = @"../kalearge.com.tr/wwwroot/Uploads";
        public UploadFilesController(IUploadFileLogic uploadFileLogic)
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
                file.FileUrl = filePath + item.FileUrl;
 
                vm.Add(file);
            }
            return View(vm);
        }

        public IActionResult AddFile()
        {
            AddFileViewModel vm = new AddFileViewModel();
            vm.IsActive = true;
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddFile(AddFileViewModel param)
        {


            if (param.UploadFile != null)
            {

                var extent = Path.GetExtension(param.UploadFile.FileName);

                var randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(filePath, randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.UploadFile.CopyTo(fileStream);

                UploadFileDtos fileDtos = new UploadFileDtos();

                fileDtos.FileName = randomName;
                fileDtos.FilePath = "Uploads/" + randomName;
                fileDtos.FileUrl = "Uploads/" + randomName;
                fileDtos.Description = param.Description;
                fileDtos.IsActive = fileDtos.IsActive;

                _uploadFileLogic.AddFile(fileDtos);

            }
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
            if (param.UploadFile != null)
            {

                var extent = Path.GetExtension(param.UploadFile.FileName);

                var randomName = ($"{Guid.NewGuid()}{extent}");

                string savePath = Path.Combine(filePath, randomName);

                using (FileStream fileStream = new FileStream((string)savePath, FileMode.Create))
                    param.UploadFile.CopyTo(fileStream);

                UploadFileDtos fileDtos = new UploadFileDtos();
                fileDtos.FileName = fileDtos.FileName;
                fileDtos.FilePath = "Uploads/" + randomName;
                fileDtos.FileUrl = "Uploads/" + randomName;
                fileDtos.Description = fileDtos.Description;
                fileDtos.IsActive = fileDtos.IsActive;
                fileDtos.Id = fileDtos.Id;


                _uploadFileLogic.UpdateFile(fileDtos);
            }
            return RedirectToAction("Index");
        }    

        public IActionResult PasiveFile(int fileId)
        {
            _uploadFileLogic.PasiveFile(fileId);

            return RedirectToAction("Index");

        }  

        public IActionResult DeleteFile(int fileId)
        {
            _uploadFileLogic.DeleteFile(fileId);

            return RedirectToAction("Index");

        }
    }
}