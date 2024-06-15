using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IProductService
    {
        void AddProduct(ProductCreateDTO productCreateDTO);
        void UpdateProduct(ProductUpdateDTO productUpdateDTO);
        void HardDeleteProduct(int id);
        void SoftDeleteProduct(int id);
        ProductGetDTO GetProduct(Func<Product, bool>? func = null);
        IQueryable<ProductGetDTO> GetAllProducts();
    }
}
