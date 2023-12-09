using KaleGroup.Data.Entities;
using KaleGroup.DataAccess.Abstract;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.Files.Interface;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Repository.Files.Command
{
    public class UploadFilesRepository : Repository<UploadFiles>, IUploadFilesRepository
    {
        public UploadFilesRepository() : base(new BaseContext())
        {

        }
        public UploadFilesRepository(BaseContext dbContext) : base(dbContext)
        {

        }
         
        public void PasiveUploadFile(int fileId)
        {
            var uploadFiles = _dbSet.Where(x => x.Id == fileId).FirstOrDefault();
            if (uploadFiles.IsActive == false)
            {
                uploadFiles.IsActive = true;
            }
            else
            {
                uploadFiles.IsActive = false;
            }
             
            _dbContext.Entry(uploadFiles).State = EntityState.Modified;

            _dbContext.SaveChanges(); 
        }
    }
}

