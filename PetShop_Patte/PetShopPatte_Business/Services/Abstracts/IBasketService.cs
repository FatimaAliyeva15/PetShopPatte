using PetShopPatte_Core.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IBasketService
    {
        Task AddProductToBasketAsync(string userId, int productId, int quantity);
        Task<Basket> GetBasketByUserIdAsync(string userId);
        Task RemoveProductFromBasketAsync(string userId, int productId);
        Task UpdateBasketItemQuantityAsync(string userId, int productId, int quantity);
    }
}
