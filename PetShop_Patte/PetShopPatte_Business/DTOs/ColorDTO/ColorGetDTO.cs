using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.ColorDTO
{
    public class ColorGetDTO
    {
        public int Id { get; set; }
        
        public string ColorName { get; set; }
    }
}
