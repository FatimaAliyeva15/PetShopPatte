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
        Task AddProduct(string environmet, ProductCreateDTO productCreateDTO);
        Task UpdateProduct(string environmet, ProductUpdateDTO productUpdateDTO);
        Task<ProductUpdateDTO> UpdateById(int id);
        Task HardDeleteProduct(int id, string environmet);
        Task SoftDeleteProduct(int id, string environmet);
        Task Recover(int id, string environmet);
        Task<Product> GetByIdAsync(int id);
        Task<IQueryable<Product>> GetAllProducts();
        Task<ProductDetail> GetProductDetailById(int id);
    }
}
