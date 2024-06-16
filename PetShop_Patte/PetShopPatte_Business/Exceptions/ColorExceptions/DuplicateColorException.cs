using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.ColorExceptions
{
    public class DuplicateColorException : Exception
    {
        public string PropertyName { get; set; }
        public DuplicateColorException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
