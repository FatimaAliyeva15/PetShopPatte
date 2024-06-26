using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Exceptions.AccountExceptions
{
    public class UserLoginException: Exception
    {
        public string PropertyName { get; }
        public UserLoginException(string? message, string propName = null) : base(message)
        {
            PropertyName = propName ?? string.Empty;
        }
    }
}
