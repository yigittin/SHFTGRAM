using SHFTGRAMAPP.Core.File;
using SHFTGRAMAPP.EFCore.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.Services.FileService
{
    public interface IFileService
    {
        public Task<UploadedFiles> FileUpload(UploadFile file, string username);
        public Task<UploadedFiles> GetFileInfo(int id);
    }
}
