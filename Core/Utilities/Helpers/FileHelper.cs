using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string Add(IFormFile file, string webRootPath)
        {
            var imagePath = CopyFileToPath(webRootPath, file);
            return imagePath;
        }

        public static string Update(string imagePath, IFormFile file, string webRootPath)
        {
            File.Delete(imagePath);
            var newImagePath = CopyFileToPath(webRootPath, file);
            return newImagePath;
        }

        public static void Delete(string filePath)
        {
            File.Delete(filePath);
        }

        private static string CopyFileToPath(string webRootPath, IFormFile file)
        {
            var uploadPath = CheckIfPathExist(webRootPath);
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, newFileName);
            var stream = new FileStream(filePath, FileMode.Create);
            file.CopyToAsync(stream);
            return filePath;
        }

        private static string CheckIfPathExist(string webRootPath)
        {
            string newPath = Path.Combine(webRootPath, "uploads");
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            return newPath;
        }
    }
}
