using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.ExternalServices.Abstractions
{
    public interface IFileUpload
    {
       Task<string> FileUploadAsync(IFormFile file, string filePath, string[] allowedExtensions);
        public void DeleteFile(IFormFile file);
    }
}
