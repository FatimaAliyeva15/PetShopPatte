using PetShopPatte_Business.DTOs.BasketItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.BasketDTO
{
    public class BasketGetDTO
    {
        public List<BasketItemGetDTO> BasketItems { get; set; }
    }
}
