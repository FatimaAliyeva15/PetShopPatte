using PetShopPatte_Core.Entities.Common;
using PetShopPatte_Core.Entities.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Core.Entities.Cart
{
    public class Basket: BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
