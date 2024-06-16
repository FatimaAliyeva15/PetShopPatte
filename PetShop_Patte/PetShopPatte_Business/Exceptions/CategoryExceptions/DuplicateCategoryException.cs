using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.CategoryExceptions
{
    public class DuplicateCategoryException : Exception
    {
        public string PropertyName { get; set; }
        public DuplicateCategoryException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
