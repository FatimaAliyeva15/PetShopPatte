using Microsoft.AspNetCore.Http;
using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities
{
    public class ProductDetail: BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
