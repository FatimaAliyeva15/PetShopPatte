using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.SizeExceptions
{
    public class SizeIdNegativeorZeroException : Exception
    {
        public SizeIdNegativeorZeroException(string? message) : base(message)
        {
        }
    }
}
