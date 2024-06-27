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
        public static string UpdateImage(this IFormFile formFile, string environment, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + formFile.FileName.Replace(" ", "");

            string path = environment + folder + fileName;
            using(FileStream fileStream = new FileStream(path, FileMode.Create))
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
