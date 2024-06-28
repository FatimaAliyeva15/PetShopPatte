using PetShopPatte_Business.DTOs.ProductDetailDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IProductDetailService
    {
        Task AddProductDetail(ProductDetailCreateDTO productDetailCreateDTO);
        Task UpdateProductDetail(ProductDetailUpdateDTO productDetailUpdateDTO);
        Task<ProductDetailUpdateDTO> UpdateById(int id);
        Task HardDeleteProductDetail(int id);
        Task SoftDeleteProductDetail(int id);
        Task Recover(int id);
        Task<ProductDetail> GetByIdAsync(int id);
        Task<IQueryable<ProductDetail>> GetAllProductDetails();
    }
}
