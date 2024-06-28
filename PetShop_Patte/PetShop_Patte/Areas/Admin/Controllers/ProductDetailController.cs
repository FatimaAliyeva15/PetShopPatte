using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.DTOs.ProductDetailDTO;
using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Business.Exceptions.ProductDetailExceptions;
using PetShopPatte_Business.Exceptions.ProductExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productDetailService.GetAllProductDetails();
            return View(products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDetailCreateDTO productDetailCreateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productDetailService.AddProductDetail(productDetailCreateDTO);
                    return RedirectToAction(nameof(Index));
                }
                catch (ProductDetailImageRequiredException ex)
                {
                    ModelState.AddModelError(ex.PropertyName, ex.Message);
                }
            }
            return View(productDetailCreateDTO);
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var productDetailUpdateDTO = await _productDetailService.UpdateById(id);
                return View(productDetailUpdateDTO);
            }
            catch (NullProductException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDetailUpdateDTO productDetailUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productDetailService.UpdateProductDetail(productDetailUpdateDTO);
                    return RedirectToAction(nameof(Index));
                }
                catch (ProductDetailImageRequiredException ex)
                {
                    ModelState.AddModelError(ex.PropertyName, ex.Message);
                }
            }
            return View(productDetailUpdateDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var productDetail = await _productDetailService.GetByIdAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            return View(productDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productDetailService.SoftDeleteProductDetail(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ProductDetailIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Recover(int id)
        {
            var productDetail = await _productDetailService.GetByIdAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            return View(productDetail);
        }

        [HttpPost, ActionName("Recover")]
        public async Task<IActionResult> RecoverConfirmed(int id)
        {
            try
            {
                await _productDetailService.Recover(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ProductDetailIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
