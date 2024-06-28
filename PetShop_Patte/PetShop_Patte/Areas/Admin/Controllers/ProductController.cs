using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Business.Exceptions.ProductExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.AddProduct(productCreateDTO);
                    return RedirectToAction(nameof(Index));
                }
                catch (ProductImageRequiredException ex)
                {
                    ModelState.AddModelError(ex.PropertyName, ex.Message);
                }
            }
            return View(productCreateDTO);
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var productUpdateDTO = await _productService.UpdateById(id);
                return View(productUpdateDTO);
            }
            catch (NullProductException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.UpdateProduct(productUpdateDTO);
                    return RedirectToAction(nameof(Index));
                }
                catch (ProductImageRequiredException ex)
                {
                    ModelState.AddModelError(ex.PropertyName, ex.Message);
                }
            }
            return View(productUpdateDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productService.SoftDeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ProductIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Recover(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Recover")]
        public async Task<IActionResult> RecoverConfirmed(int id)
        {
            try
            {
                await _productService.Recover(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ProductIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
