using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Helpers
{
    public static class FileManager
    {
        public static string AddImage(this IFormFile formFile, string environment, string folder)
        {
            string folderPath = Path.Combine(environment, folder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            string fullPath = Path.Combine(folderPath, fileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            return fileName;
        }

        public static string UpdateImage(this IFormFile formFile, string environment, string folder)
        {
            // Ensure the folder exists
            string folderPath = Path.Combine(environment, folder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Generate a unique file name
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName).Replace(" ", "");
            string fullPath = Path.Combine(folderPath, fileName);

            // Save the file
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            return fileName;
        }

        public static bool CheckImgFile(this IFormFile formFile)
        {
            return formFile.ContentType.Contains("image/") && formFile.Length / 1024 / 1024 <= 3;
        }


        public static void DeleteImage(this string image, string environment, string folder)
        {
            string path = environment + folder + image;

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
