using PetShopPatte_Business.DTOs.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.BasketItemDTO
{
    public class BasketItemGetDTO
    {
        public ProductGetDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
