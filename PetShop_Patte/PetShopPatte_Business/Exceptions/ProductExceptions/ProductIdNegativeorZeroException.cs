using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ProductExceptions
{
    public class ProductIdNegativeorZeroException : Exception
    {
        public ProductIdNegativeorZeroException(string? message) : base(message)
        {
        }
    }
}
