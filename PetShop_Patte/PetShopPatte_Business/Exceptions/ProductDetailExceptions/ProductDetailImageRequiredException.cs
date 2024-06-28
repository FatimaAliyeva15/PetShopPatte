using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ProductDetailExceptions
{
    public class ProductDetailImageRequiredException : Exception
    {
        public string PropertyName { get; set; }
        public ProductDetailImageRequiredException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
