using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.Files.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.Files.Command
{
    public class FilesRepository:IFilesRepository
    {
        private readonly IRepository<KaleGroup.Data.Entities.Files> _fileRepository;
        private readonly BaseContext _dbContext;
        public FilesRepository(IRepository<KaleGroup.Data.Entities.Files> fileRepository, BaseContext dbContext)
        {
            _fileRepository = fileRepository;
            _dbContext = dbContext;

        }
        public bool AddFiles(KaleGroup.Data.Entities.Files files)
        {
            var result = _fileRepository.InsertAsync(files);
            if (result != null)
                return true;

            return false;
        }

        public List<KaleGroup.Data.Entities.Files> GetFilesList()
        {
            return _fileRepository.Table.ToList();
        }
        public KaleGroup.Data.Entities.Files GetFiles(int Id)
        {
            return _fileRepository.Table.Where(x=>x.Id==Id).FirstOrDefault();
        }

        public bool UpdateFiles(KaleGroup.Data.Entities.Files files)
        {
            var file = _fileRepository.Table.Where(x => x.Id == files.Id).FirstOrDefault();

            file.FileName = files.FileName;
            file.FileUrl = files.FileUrl;
           
            _dbContext.Entry(file).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return true;
        }

        public bool DeleteFiles(int fileId)
        {
            var file = _fileRepository.Table.Where(x => x.Id == fileId).FirstOrDefault();
            _fileRepository.Delete(file);

            //file.FileName = files.FileName;
            //file.FileUrl = files.FileUrl;

            //_dbContext.Entry(file).State = EntityState.Modified;

            //_dbContext.SaveChanges();

            return true;
        }
    }
}


//bool AddFiles(KaleGroup.Data.Entities.Files files);
//List<KaleGroup.Data.Entities.Files> GetFilesList();
//bool UpdateFiles(KaleGroup.Data.Entities.Files files);
//bool DeleteFiles(int fileID);
//KaleGroup.Data.Entities.Files GetFiles(int Id);