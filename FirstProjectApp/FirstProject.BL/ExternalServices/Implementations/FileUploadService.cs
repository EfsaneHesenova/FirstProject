using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProject.BL.ExternalServices.Abstractions;
using Microsoft.AspNetCore.Http;

namespace FirstProject.BL.ExternalServices.Implementations
{
    public class FileUploadService : IFileUploadService
    {
        public void DeleteFile(string FileNameWithExtension, string envPath)
        {
            if(string.IsNullOrEmpty(FileNameWithExtension)) { throw new ArgumentNullException(nameof(FileNameWithExtension)); }
            var path = Path.Combine(envPath, "Uploads", FileNameWithExtension );

            if(!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            File.Delete(path);
        }

        public async Task<string> FileUploadAsync(IFormFile file, string envPath, string[] allowedExtensions)
        {
            if(file is null) throw new ArgumentNullException(nameof(file));
            var contentPath = Path.Combine(envPath, "Uploads");
            if(!File.Exists(contentPath))
            {
                Directory.CreateDirectory(contentPath);
            }
            var ext = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(ext))
            {
                throw new ArgumentException();
            }
            var fileName = $"{Guid.NewGuid}{ext}";
            var filePath = Path.Combine(contentPath, fileName);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(stream);
            }
            return fileName;

        }
    }
}
