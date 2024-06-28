using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.SubcategoryExceptions
{
    public class SubcategoryIdNegativeorZeroException : Exception
    {
        public SubcategoryIdNegativeorZeroException(string? message) : base(message)
        {
        }
    }
}
