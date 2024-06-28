using Microsoft.EntityFrameworkCore;
using PetShopPatte_Core.Entities.Cart;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.DAL;
using PetShopPatte_Data.Repositories.Abstracts;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Repositories.Concretes
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Basket> GetBasketByUserIdAsync(string userId)
        {
            return await _table.Include(b => b.BasketItems)
                               .ThenInclude(bi => bi.Product)
                               .FirstOrDefaultAsync(b => b.AppUserId == userId && !b.IsDeleted);
        }

        public async Task AddProductToBasketAsync(string userId, int productId, int quantity)
        {
            var basket = await GetBasketByUserIdAsync(userId);
            if (basket == null)
            {
                basket = new Basket { AppUserId = userId, BasketItems = new List<BasketItem>() };
                await AddAsync(basket);
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

            Update(basket);
            await Commit();
        }
    }
}