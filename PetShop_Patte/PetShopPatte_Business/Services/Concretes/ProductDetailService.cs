using PetShopPatte_Business.DTOs.ProductDetailDTO;
using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Business.Exceptions.ProductDetailExceptions;
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
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository _productDetailRepository;
        public readonly string _environment;

        public ProductDetailService(IProductDetailRepository productDetailRepository, string environment)
        {
            _productDetailRepository = productDetailRepository;
            _environment = environment;
        }

        public Task AddProductDetail(ProductDetailCreateDTO productDetailCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductDetail(ProductDetailUpdateDTO productDetailUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetailUpdateDTO> UpdateById(int id)
        {
            throw new NotImplementedException();
        }

        public Task HardDeleteProductDetail(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteProductDetail(int id)
        {
            throw new NotImplementedException();
        }

        public Task Recover(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetail> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ProductDetail>> GetAllProductDetails()
        {
            throw new NotImplementedException();
        }

        //public async Task AddProductDetail(ProductDetailCreateDTO productDetailCreateDTO)
        //{
        //    if (productDetailCreateDTO.ImgFile != null && productDetailCreateDTO.ImgFile.CheckImgFile())
        //    {
        //        string imgPath = productDetailCreateDTO.ImgFile.UpdateImage(_environment, "ProductDetailImages/");
        //        ProductDetail productDetail = new ProductDetail
        //        {
        //            Description = productDetailCreateDTO.Description,
        //            Price = productDetailCreateDTO.Price,
        //            StockQuantity = productDetailCreateDTO.StockQuantity,
        //            ProductId = productDetailCreateDTO.ProductId,
        //            ImgUrl = imgPath,
        //            CreatedDate = DateTime.UtcNow,
        //            UpdatedDate = DateTime.UtcNow,
        //        };

        //        await _productDetailRepository.AddAsync(productDetail);
        //        await _productDetailRepository.Commit();
        //    }

        //    else
        //    {
        //        throw new ProductDetailImageRequiredException("ImgFile", "Image is required");
        //    }
        //}

        //public async Task<IQueryable<ProductDetail>> GetAllProductDetails()
        //{
        //    return await _productDetailRepository.GetAllAsync();
        //}

        //public async Task<ProductDetail> GetByIdAsync(int id)
        //{
        //    return await _productDetailRepository.GetByIdAsync(id);
        //}

        //public async Task HardDeleteProductDetail(int id)
        //{
        //    if (id <= 0)
        //        throw new ProductDetailIdNegativeorZeroException("Product id not negative and zero");

        //    await _productDetailRepository.HardDelete(id);
        //    await _productDetailRepository.Commit();
        //}

        //public async Task Recover(int id)
        //{

        //    if (id <= 0)
        //        throw new ProductDetailIdNegativeorZeroException("Product id not negative and zero");

        //    await _productDetailRepository.Recover(id);
        //    await _productDetailRepository.Commit();
        //}

        //public async Task SoftDeleteProductDetail(int id)
        //{

        //    if (id <= 0)
        //        throw new ProductDetailIdNegativeorZeroException("Product id not negative and zero");

        //    await _productDetailRepository.SoftDelete(id);
        //    await _productDetailRepository.Commit();
        //}

        //public async Task<ProductDetailUpdateDTO> UpdateById(int id)
        //{
        //    var existProductDetail = await _productDetailRepository.GetByIdAsync(id);

        //    if (existProductDetail != null && !existProductDetail.IsDeleted)
        //    {
        //        return new ProductDetailUpdateDTO
        //        {
        //            Id = existProductDetail.Id,
        //            Description = existProductDetail.Description,
        //            Price = existProductDetail.Price,
        //            ProductId = existProductDetail.ProductId,
        //            StockQuantity = existProductDetail.StockQuantity,
        //            ImgFile = null // ImgFile cannot be assigned directly, typically set via a view form
        //        };
        //    }
        //    else
        //    {
        //        throw new NullProductDetailException("Product detail cannot be null");
        //    }
        //}

        //public async Task UpdateProductDetail(ProductDetailUpdateDTO productDetailUpdateDTO)
        //{
        //    var existProductDetail = await _productDetailRepository.GetByIdAsync(productDetailUpdateDTO.Id);

        //    if (existProductDetail != null && !existProductDetail.IsDeleted)
        //    {
        //        existProductDetail.Id = existProductDetail.Id;
        //        existProductDetail.Description = existProductDetail.Description;
        //        existProductDetail.Price = existProductDetail.Price;
        //        existProductDetail.ProductId = existProductDetail.ProductId;
        //        existProductDetail.StockQuantity = existProductDetail.StockQuantity;
        //        existProductDetail.UpdatedDate = DateTime.UtcNow;

        //        if (productDetailUpdateDTO.ImgFile != null && productDetailUpdateDTO.ImgFile.CheckImgFile())
        //        {
        //            string imgPath = productDetailUpdateDTO.ImgFile.UpdateImage(_environment, "ProductDetailImages/");
        //            if (!string.IsNullOrEmpty(existProductDetail.ImgUrl))
        //            {

        //                existProductDetail.ImgUrl.DeleteImage(_environment, "ProductDetailImages/");
        //            }
        //            existProductDetail.ImgUrl = imgPath;
        //        }
        //        else
        //        {
        //            throw new ProductDetailImageRequiredException("ImgFile", "Image is required");
        //        }

        //        _productDetailRepository.Update(existProductDetail);
        //        await _productDetailRepository.Commit();
        //    }
        //}
    }
}
