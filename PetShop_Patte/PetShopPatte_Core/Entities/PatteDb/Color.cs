using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities.PatteDb
{
    public class Color : BaseAuditableEntity
    {

        public string ColorName { get; set; }
        public List<Product>? Products { get; set; }
        public List<Pet> Pets { get; set; }

    }
}
