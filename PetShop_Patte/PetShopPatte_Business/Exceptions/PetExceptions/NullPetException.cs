using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.PetExceptions
{
    public class NullPetException : Exception
    {
        public NullPetException(string? message) : base(message)
        {
        }
    }
}
