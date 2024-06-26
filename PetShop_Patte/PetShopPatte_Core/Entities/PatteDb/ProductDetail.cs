using Microsoft.AspNetCore.Http;
using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities.PatteDb
{
    public class ProductDetail : BaseEntity
    {

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
