using Microsoft.AspNetCore.Http;
using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities.PatteDb
{
    public class Pet : BaseEntity
    {

        public string Name { get; set; }
        public byte Age { get; set; }

        public string Gender { get; set; }

        public string Breed { get; set; }
        public int? TypeId { get; set; }
        public AnimalType? AnimalType { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public int? SizeId { get; set; }
        public Size? Size { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }

    }
}
