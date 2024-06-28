using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ProductExceptions
{
    public class NullProductException : Exception
    {
        public NullProductException(string? message) : base(message)
        {
        }
    }
}
