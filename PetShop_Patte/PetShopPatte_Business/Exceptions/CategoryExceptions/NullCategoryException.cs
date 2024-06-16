using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.CategoryExceptions
{
    public class NullCategoryException : Exception
    {
        public NullCategoryException(string? message) : base(message)
        {
        }
    }
}
