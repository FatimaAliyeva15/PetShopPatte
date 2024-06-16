using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.AnimalTypeExceptions
{
    public class DuplicateAnimalTypeException : Exception
    {
        public string PropertyName { get; set; }
        public DuplicateAnimalTypeException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
