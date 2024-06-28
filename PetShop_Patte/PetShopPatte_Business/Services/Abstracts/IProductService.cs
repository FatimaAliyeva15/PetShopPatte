using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IProductService
    {
        Task AddProduct(ProductCreateDTO productCreateDTO);
        Task UpdateProduct(ProductUpdateDTO productUpdateDTO);
        Task<ProductUpdateDTO> UpdateById(int id);
        Task HardDeleteProduct(int id);
        Task SoftDeleteProduct(int id);
        Task Recover(int id);
        Task<Product> GetByIdAsync(int id);
        Task<IQueryable<Product>> GetAllProducts();
    }
}
