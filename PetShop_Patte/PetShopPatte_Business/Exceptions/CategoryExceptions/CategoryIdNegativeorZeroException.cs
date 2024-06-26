using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.CategoryExceptions
{
    public class CategoryIdNegativeorZeroException : Exception
    {
        public CategoryIdNegativeorZeroException(string? message) : base(message)
        {
        }
    }
}
