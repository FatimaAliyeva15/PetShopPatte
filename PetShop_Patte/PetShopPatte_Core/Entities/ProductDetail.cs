using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities
{
    public class ProductDetail: BaseEntity
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
