using Microsoft.EntityFrameworkCore;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.DAL;
using PetShopPatte_Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Repositories.Concretes
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<ProductDetail> GetPetDetailByIdAsync(int id)
        {
            return await _appDbContext.ProductDetails
                                 .Include(pd => pd.Product)
                                 .FirstOrDefaultAsync(pd => pd.Id == id);
        }
    }
}
