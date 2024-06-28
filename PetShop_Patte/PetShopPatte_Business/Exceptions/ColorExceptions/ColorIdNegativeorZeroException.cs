using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ColorExceptions
{
    public class ColorIdNegativeorZeroException : Exception
    {
        public ColorIdNegativeorZeroException(string? message) : base(message)
        {
        }
    }
}
