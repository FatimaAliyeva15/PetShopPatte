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
    public class Product : BaseAuditableEntity
    {

        public string Name { get; set; }
        public int? SubcategoryId { get; set; }
        public int? AnimalTypeId { get; set; }
        public Subcategory? Subcategory { get; set; }
        public AnimalType? AnimalType { get; set; }
        public List<Size>? Sizes { get; set; }
        public List<Color>? Colors { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
        public string? ImgUrl { get; set; }
        
    }
}
