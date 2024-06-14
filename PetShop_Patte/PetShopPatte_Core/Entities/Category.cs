using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities
{
    public class Category: BaseEntity
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
    }
}
