using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.ExternalServices.Abstractions
{
    public interface IFileUploadService
    {
        Task<string> FileUploadAsync(IFormFile file, string envPath, string[] allowedExtensions);
        public void DeleteFile(string FileNameWithExtension, string envPath);
    }
}
