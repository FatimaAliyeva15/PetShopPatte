﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.ColorDTO
{
    public class ColorCreateDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string ColorName { get; set; }
    }
}
