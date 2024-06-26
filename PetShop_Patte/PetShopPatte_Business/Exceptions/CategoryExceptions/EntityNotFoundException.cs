﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.CategoryExceptions
{
    public class EntityNotFoundException: Exception
    {
        public string PropertyName { get; set; }
        public EntityNotFoundException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
