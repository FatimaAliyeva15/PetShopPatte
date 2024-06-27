using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities.PatteDb
{
    public class Size : BaseAuditableEntity
    {

        public string SizeName { get; set; }
        public List<Product>? Products { get; set; }
        public List<Pet> Pets { get; set; }

    }
}
