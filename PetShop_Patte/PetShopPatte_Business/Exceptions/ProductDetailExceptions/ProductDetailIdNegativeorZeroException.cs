using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ProductDetailExceptions
{
    public class ProductDetailIdNegativeorZeroException : Exception
    {
        public ProductDetailIdNegativeorZeroException(string? message) : base(message)
        {
        }
    }
}
