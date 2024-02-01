using EFCore;
using SHFTGRAMAPP.Core.Exceptions;
using SHFTGRAMAPP.Core.File;
using SHFTGRAMAPP.EFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.Services.FileService
{
    public class FileService:IFileService
    {
        private readonly IConfiguration _configs;
        private readonly DataContext _context;

        public FileService(IConfiguration configs, DataContext context)
        {
            _configs = configs;
            _context = context;
        }

        public async Task<UploadedFiles> FileUpload(UploadFile file,string username)
        {
            try
            {
                var newFile = new UploadedFiles()
                {
                    FileExtention=file.FileExt,
                    FileName=file.FileName,
                    OldFileName=file.OldFileName,                    
                    CreatedBy=username,
                    CreateTime=DateTime.Now,
                    IsDeleted=false,
                    ModifiedBy=username,
                    ModifiedTime=DateTime.Now,
                    Path=file.Path,
                };
                await _context.Files.AddAsync(newFile);
                await _context.SaveChangesAsync();
                return newFile;
            }catch(Exception ex) {
                throw new CustomException("Upload Fail : "+ex.Message);
            }
        }
        public async Task<UploadedFiles> GetFileInfo(int id)
        {
            try
            {
                var file = await _context.Files.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
                if (file is null)
                    throw new NotFoundException("File");
                return file;
            }
            catch (Exception ex)
            {
                throw new CustomException("File failed : "+ex.Message);
            }
            
        }
    }
}
