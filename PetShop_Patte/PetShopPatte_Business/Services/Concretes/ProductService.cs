using AutoMapper;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Business.Exceptions.PetExceptions;
using PetShopPatte_Business.Exceptions.ProductExceptions;
using PetShopPatte_Business.Helpers;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.Repositories.Abstracts;
using PetShopPatte_Data.Repositories.Concretes;
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
        private readonly string _environment;


        public ProductService(IProductRepository productRepository, string environment)
        {
            _productRepository = productRepository;
            _environment = environment;
        }

        public Task AddProduct(ProductCreateDTO productCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task HardDeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task Recover(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductUpdateDTO> UpdateById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            throw new NotImplementedException();
        }

        //public async Task AddProduct(ProductCreateDTO productCreateDTO)
        //{
        //    if (productCreateDTO.ImgFile != null && productCreateDTO.ImgFile.CheckImgFile())
        //    {
        //        string imgPath = productCreateDTO.ImgFile.UpdateImage(_environment, "ProductImages/");
        //        Product product = new Product
        //        {
        //            Name = productCreateDTO.Name,
        //            Price = productCreateDTO.Price,
        //            SubcategoryId = productCreateDTO.SubcategoryId,
        //            AnimalTypeId = productCreateDTO.AnimalTypeId,
        //            ImgUrl = imgPath,
        //            CreatedDate = DateTime.UtcNow,
        //            UpdatedDate = DateTime.UtcNow,
        //        };

        //        await _productRepository.AddAsync(product);
        //        await _productRepository.Commit();
        //    }

        //    else
        //    {
        //        throw new ProductImageRequiredException("ImgFile", "Image is required");
        //    }
        //}

        //public async Task<IQueryable<Product>> GetAllProducts()
        //{
        //    return await _productRepository.GetAllAsync();
        //}

        //public async Task<Product> GetByIdAsync(int id)
        //{
        //    return await _productRepository.GetByIdAsync(id);
        //}

        //public async Task HardDeleteProduct(int id)
        //{
        //    if (id <= 0)
        //        throw new ProductIdNegativeorZeroException("Product id not negative and zero");

        //    await _productRepository.HardDelete(id);
        //    await _productRepository.Commit();
        //}

        //public async Task Recover(int id)
        //{
        //    if (id <= 0)
        //        throw new ProductIdNegativeorZeroException("Product id not negative and zero");

        //    await _productRepository.Recover(id);
        //    await _productRepository.Commit();
        //}

        //public async Task SoftDeleteProduct(int id)
        //{
        //    if (id <= 0)
        //        throw new ProductIdNegativeorZeroException("Product id not negative and zero");

        //    await _productRepository.SoftDelete(id);
        //    await _productRepository.Commit();
        //}

        //public async Task<ProductUpdateDTO> UpdateById(int id)
        //{
        //    var existProduct = await _productRepository.GetByIdAsync(id);

        //    if (existProduct != null && !existProduct.IsDeleted)
        //    {
        //        return new ProductUpdateDTO
        //        {
        //            Id = existProduct.Id,
        //            Name = existProduct.Name,
        //            Price = existProduct.Price,
        //            AnimalTypeId = existProduct.AnimalTypeId,
        //            SubcategoryId = existProduct.SubcategoryId,
        //            ImgFile = null // ImgFile cannot be assigned directly, typically set via a view form
        //        };
        //    }
        //    else
        //    {
        //        throw new NullProductException("Product cannot be null");
        //    }
        //}

        //public async Task UpdateProduct(ProductUpdateDTO productUpdateDTO)
        //{
        //    var existProduct = await _productRepository.GetByIdAsync(productUpdateDTO.Id);

        //    if (existProduct != null && !existProduct.IsDeleted)
        //    {
        //        existProduct.Name = productUpdateDTO.Name;
        //        existProduct.Price = productUpdateDTO.Price;
        //        existProduct.AnimalTypeId = productUpdateDTO.AnimalTypeId;
        //        existProduct.SubcategoryId = productUpdateDTO.SubcategoryId;
        //        existProduct.UpdatedDate = DateTime.UtcNow;

        //        if (productUpdateDTO.ImgFile != null && productUpdateDTO.ImgFile.CheckImgFile())
        //        {
        //            string imgPath = productUpdateDTO.ImgFile.UpdateImage(_environment, "ProductImages/");
        //            if (!string.IsNullOrEmpty(existProduct.ImgUrl))
        //            {
        //                existProduct.ImgUrl.DeleteImage(_environment, "ProductImages/");
        //            }
        //            existProduct.ImgUrl = imgPath;
        //        }
        //        else
        //        {
        //            throw new ProductImageRequiredException("ImgFile", "Image is required");
        //        }

        //        _productRepository.Update(existProduct);
        //        await _productRepository.Commit();
        //    }
        //}
    }
}
