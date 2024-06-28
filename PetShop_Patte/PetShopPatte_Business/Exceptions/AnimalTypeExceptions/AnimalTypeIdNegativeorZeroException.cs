using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.AnimalTypeExceptions
{
    public class AnimalTypeIdNegativeorZeroException : Exception
    {
        public AnimalTypeIdNegativeorZeroException(string? message) : base(message)
        {
        }
    }
}
