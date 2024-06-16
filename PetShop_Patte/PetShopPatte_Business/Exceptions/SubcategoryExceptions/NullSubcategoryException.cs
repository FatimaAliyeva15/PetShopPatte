using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.SubcategoryExceptions
{
    public class NullSubcategoryException : Exception
    {
        public NullSubcategoryException(string? message) : base(message)
        {
        }
    }
}
