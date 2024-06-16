using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ColorExceptions
{
    public class NullColorException : Exception
    {
        public NullColorException(string? message) : base(message)
        {
        }
    }
}
