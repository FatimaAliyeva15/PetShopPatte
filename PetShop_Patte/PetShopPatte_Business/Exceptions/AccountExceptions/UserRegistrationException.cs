using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.AccountExceptions
{
    public class UserRegistrationException: Exception
    {
        public string PropertyName { get; set; }
        public UserRegistrationException(string? message, string propName) : base(message)
        {
            PropertyName = propName ?? string.Empty;
        }
    }
}
