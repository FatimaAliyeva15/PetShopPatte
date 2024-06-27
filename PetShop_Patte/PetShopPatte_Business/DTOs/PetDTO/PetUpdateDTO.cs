using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.PetDTO
{
    public class PetUpdateDTO
    {
        public int Id { get; set; }
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
