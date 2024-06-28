using PetShopPatte_Core.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Repositories.Abstracts
{
    public interface IBasketRepository: IGenericRepository<Basket>
    {
        Task<Basket> GetBasketByUserIdAsync(string userId);
        Task AddProductToBasketAsync(string userId, int productId, int quantity);
    }
}
