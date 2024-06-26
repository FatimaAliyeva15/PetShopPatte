using AutoMapper;
using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddProduct(ProductCreateDTO productCreateDTO)
        {
            throw new NotImplementedException();
        }

        public ICollection<ProductGetDTO> GetAllProducts(Func<Product, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public ProductGetDTO GetProduct(Func<Product, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public void HardDeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
