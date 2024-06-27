using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.PetExceptions
{
    public class PetImageRequiredException: Exception
    {
        public string PropertyName { get; set; }
        public PetImageRequiredException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
