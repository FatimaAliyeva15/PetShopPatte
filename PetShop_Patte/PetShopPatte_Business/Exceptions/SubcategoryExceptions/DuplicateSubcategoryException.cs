﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.SubcategoryExceptions
{
    public class DuplicateSubcategoryException : Exception
    {
        public string PropertyName { get; set; }
        public DuplicateSubcategoryException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
