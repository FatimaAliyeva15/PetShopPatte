using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ProductDetailExceptions
{
    public class NullProductDetailException : Exception
    {
        public NullProductDetailException(string? message) : base(message)
        {
        }
    }
}
