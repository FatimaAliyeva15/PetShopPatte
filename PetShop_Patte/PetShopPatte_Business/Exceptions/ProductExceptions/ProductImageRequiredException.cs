﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ProductExceptions
{
    public class ProductImageRequiredException : Exception
    {
        public string PropertyName { get; set; }
        public ProductImageRequiredException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
