﻿using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities
{
    public class Subcategory: BaseEntity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string SubcategoryName { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Product> Products { get; set; }
    }
}
