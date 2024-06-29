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
        //private readonly string _environment;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
           // _environment = environment;
        }

        public async Task AddProduct(string environment, ProductCreateDTO productCreateDTO)
        {
            if (productCreateDTO.ImgFile != null && productCreateDTO.ImgFile.CheckImgFile())
            {
                // Ensure the environment path is correct and ends with a directory separator
                string webRootPath = Path.Combine(environment, "ProductImages");

                // Save image to the specified folder
                string imgPath = productCreateDTO.ImgFile.AddImage(webRootPath, "");

                Product pet = new Product
                {
                    Name = productCreateDTO.Name,
                    Price = productCreateDTO.Price,
                    SubcategoryId = productCreateDTO.SubcategoryId,
                    AnimalTypeId = productCreateDTO.AnimalTypeId,
                    ImgUrl = imgPath,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                };

                await _productRepository.AddAsync(pet);
                await _productRepository.Commit();
            }
            else
            {
                throw new ProductImageRequiredException("ImgFile", "Image is required");
            }
        }

        public async Task<IQueryable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<ProductDetail> GetProductDetailById(int id)
        {
            return await _productRepository.GetPetDetailByIdAsync(id);
        }

        public async Task HardDeleteProduct(int id, string environment)
        {
            if (id <= 0)
                throw new ProductIdNegativeorZeroException("Product id not negative and zero");

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null || product.IsDeleted)
            {
                throw new NullProductException("Pet cannot be null or already deleted.");
            }

            // Delete the image
            if (!string.IsNullOrEmpty(product.ImgUrl))
            {
                product.ImgUrl.DeleteImage(environment, "ProductImages/");
            }

            await _productRepository.HardDelete(id);
            await _productRepository.Commit();
        }

        public async Task Recover(int id, string environment)
        {

            if (id <= 0)
                throw new ProductIdNegativeorZeroException("Product id not negative and zero");

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null || product.IsDeleted)
            {
                throw new NullProductException("Pet cannot be null or already deleted.");
            }

            // Delete the image
            if (!string.IsNullOrEmpty(product.ImgUrl))
            {
                product.ImgUrl.DeleteImage(environment, "ProductImages/");
            }

            await _productRepository.Recover(id);
            await _productRepository.Commit();
        }

        public async Task SoftDeleteProduct(int id, string environment)
        {

            if (id <= 0)
                throw new ProductIdNegativeorZeroException("Product id not negative and zero");

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null || product.IsDeleted)
            {
                throw new NullProductException("Pet cannot be null or already deleted.");
            }

            // Delete the image
            if (!string.IsNullOrEmpty(product.ImgUrl))
            {
                product.ImgUrl.DeleteImage(environment, "ProductImages/");
            }

            await _productRepository.SoftDelete(id);
            await _productRepository.Commit();
        }

        public async Task<ProductUpdateDTO> UpdateById(int id)
        {

            var existProduct = await _productRepository.GetByIdAsync(id);

            if (existProduct != null && !existProduct.IsDeleted)
            {
                return new ProductUpdateDTO
                {
                    Id = existProduct.Id,
                    Name = existProduct.Name,
                    Price = existProduct.Price,
                    AnimalTypeId = existProduct.AnimalTypeId,
                    SubcategoryId = existProduct.SubcategoryId,
                    ImgFile = null // ImgFile cannot be assigned directly, typically set via a view form
                };
            }
            else
            {
                throw new NullProductException("Product cannot be null");
            }
        }

        public async Task UpdateProduct(string environment, ProductUpdateDTO productUpdateDTO)
        {
            var existProduct = await _productRepository.GetByIdAsync(productUpdateDTO.Id);

            if (existProduct != null && !existProduct.IsDeleted)
            {
                existProduct.Name = productUpdateDTO.Name;
                existProduct.Price = productUpdateDTO.Price;
                existProduct.SubcategoryId = productUpdateDTO.SubcategoryId;
                existProduct.AnimalTypeId = productUpdateDTO.AnimalTypeId;


                if (productUpdateDTO.ImgFile != null && productUpdateDTO.ImgFile.CheckImgFile())
                {
                    string imgPath = productUpdateDTO.ImgFile.UpdateImage(environment, "ProdutImages/");
                    if (!string.IsNullOrEmpty(existProduct.ImgUrl))
                    {
                        existProduct.ImgUrl.DeleteImage(environment, "ProductImages/");
                    }
                    existProduct.ImgUrl = imgPath;
                }
                else
                {
                    throw new ProductImageRequiredException("ImgFile", "Image is required");
                }

                _productRepository.Update(existProduct);
                await _productRepository.Commit();
            }
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
