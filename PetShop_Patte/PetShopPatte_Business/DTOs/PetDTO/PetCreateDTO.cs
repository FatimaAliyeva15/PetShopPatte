using Microsoft.AspNetCore.Http;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.PetDTO
{
    public class PetCreateDTO
    {
        public string Name { get; set; }
        public byte Age { get; set; }

        public string Gender { get; set; }

        public string Breed { get; set; }
        public int? TypeId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
