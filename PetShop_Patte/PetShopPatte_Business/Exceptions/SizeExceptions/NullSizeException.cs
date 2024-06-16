using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.SizeExceptions
{
    public class NullSizeException : Exception
    {
        public NullSizeException(string? message) : base(message)
        {
        }
    }
}
