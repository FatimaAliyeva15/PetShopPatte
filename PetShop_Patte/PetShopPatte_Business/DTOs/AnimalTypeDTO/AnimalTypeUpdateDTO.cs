using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.AnimalTypeDTO
{
    public class AnimalTypeUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Type { get; set; }
    }
}
