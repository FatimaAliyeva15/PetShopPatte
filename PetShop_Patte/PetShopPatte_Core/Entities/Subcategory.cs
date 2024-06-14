using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities
{
    public class Subcategory: BaseEntity
    {
        public string SubcategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
