﻿using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities
{
    public class Pet: BaseEntity
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public int TypeId { get; set; }
        public AnimalType AnimalType { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public string ImgUrl { get; set; }

    }
}
