﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.SizeExceptions
{
    public class DuplicateSizeException : Exception
    {
        public string PropertyName { get; set; }
        public DuplicateSizeException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
