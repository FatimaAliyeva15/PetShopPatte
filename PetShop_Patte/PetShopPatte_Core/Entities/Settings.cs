using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities
{
    public class Settings: BaseAuditableEntity
    {
        public string Description { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string LogoUrl { get; set;}
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
