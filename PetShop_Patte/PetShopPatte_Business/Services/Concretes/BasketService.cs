using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.Cart;
using PetShopPatte_Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Concretes
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        public BasketService(IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        public async Task<Basket> GetBasketByUserIdAsync(string userId)
        {
            return await _basketRepository.GetBasketByUserIdAsync(userId);
        }

        public async Task AddProductToBasketAsync(string userId, int productId, int quantity)
        {
            var basket = await _basketRepository.GetBasketByUserIdAsync(userId);
            if (basket == null)
            {
                basket = new Basket { AppUserId = userId, BasketItems = new List<BasketItem>() };
                await _basketRepository.AddAsync(basket);
            }

            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new ApplicationException($"Product with ID {productId} not found.");
            }

            var basketItem = basket.BasketItems.FirstOrDefault(bi => bi.ProductId == productId);
            if (basketItem == null)
            {
                basketItem = new BasketItem { ProductId = productId, Quantity = quantity, BasketId = basket.Id };
                basket.BasketItems.Add(basketItem);
            }
            else
            {
                basketItem.Quantity += quantity;
            }

            _basketRepository.Update(basket);
            await _basketRepository.Commit();
        }

        public async Task RemoveProductFromBasketAsync(string userId, int productId)
        {
            var basket = await _basketRepository.GetBasketByUserIdAsync(userId);
            if (basket == null)
            {
                throw new ApplicationException($"Basket for user with ID {userId} not found.");
            }

            var basketItem = basket.BasketItems.FirstOrDefault(bi => bi.ProductId == productId);
            if (basketItem != null)
            {
                basket.BasketItems.Remove(basketItem);
                _basketRepository.Update(basket);
                await _basketRepository.Commit();
            }
        }

        public async Task UpdateBasketItemQuantityAsync(string userId, int productId, int quantity)
        {
            var basket = await _basketRepository.GetBasketByUserIdAsync(userId);
            if (basket == null)
            {
                throw new ApplicationException($"Basket for user with ID {userId} not found.");
            }

            var basketItem = basket.BasketItems.FirstOrDefault(bi => bi.ProductId == productId);
            if (basketItem != null)
            {
                basketItem.Quantity = quantity;
                _basketRepository.Update(basket);
                await _basketRepository.Commit();
            }
        }
    }
}
