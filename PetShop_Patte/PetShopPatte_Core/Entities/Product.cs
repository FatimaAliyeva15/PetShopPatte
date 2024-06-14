using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public int SubcategoryId { get; set; }
        public int AnimalTypeId { get; set; }
        public Subcategory Subcategory { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
