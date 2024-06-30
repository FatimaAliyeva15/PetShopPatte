using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Business.Exceptions.PetExceptions;
using PetShopPatte_Business.Exceptions.ProductExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;
using System.Threading.Tasks;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAnimalTypeService _animalTypeService;
        private readonly ISizeService _sizeService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IValidator<ProductCreateDTO> _validator;
        private readonly IValidator<ProductUpdateDTO> _updateValidator;
        private readonly IWebHostEnvironment _environment;

		public ProductController(IProductService productService, IValidator<ProductCreateDTO> validator, IValidator<ProductUpdateDTO> updateValidator, IWebHostEnvironment environment, IAnimalTypeService animalTypeService, ISubcategoryService subcategoryService, ISizeService sizeService)
		{
			_productService = productService;
			_validator = validator;
			_updateValidator = updateValidator;
			_environment = environment;
			_animalTypeService = animalTypeService;
			_subcategoryService = subcategoryService;
			_sizeService = sizeService;
		}

		public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products.ToList());
        }

        public async Task<IActionResult> Create()
        {
            var animalTypes = await _animalTypeService.GetAllAnimalTypes();
            ViewBag.AnimalTypes = new SelectList(animalTypes, "Id", "Type");

            var subcategories = await _subcategoryService.GetAllSubcategories();
            ViewBag.Subcategories = new SelectList(subcategories, "Id", "SubcategoryName");

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            ProductCreateDTOValidation validations = new ProductCreateDTOValidation();
            var validationResult = await _validator.ValidateAsync(productCreateDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(productCreateDTO);
            }

            try
            {
                await _productService.AddProduct(_environment.WebRootPath, productCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ProductImageRequiredException ex)
            {
                ModelState.AddModelError("ImgFile", ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ModelState.AddModelError(string.Empty, "Error adding product.");
            }

            var animalTypes = await _animalTypeService.GetAllAnimalTypes();
            ViewBag.AnimalTypes = new SelectList(animalTypes, "Id", "Type");

            var subcategory = await _subcategoryService.GetAllSubcategories();
            ViewBag.Subcategories = new SelectList(subcategory, "Id", "SubcategoryName");


			return View(productCreateDTO);
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var productUpdateDTO = await _productService.UpdateById(id);

                var animalTypes = await _animalTypeService.GetAllAnimalTypes();
                ViewBag.AnimalTypes = new SelectList(animalTypes, "Id", "Type");

                var subcategory = await _subcategoryService.GetAllSubcategories();
                ViewBag.Subcategories = new SelectList(subcategory, "Id", "SubcategoryName");


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
                    await _productService.UpdateProduct(_environment.WebRootPath, productUpdateDTO);
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
            try
            {
                string environmentPath = _environment.WebRootPath;
                await _productService.HardDeleteProduct(id, environmentPath);
            }
            catch (ProductIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullProductException ex)
            {
                return NotFound(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                string environmentPath = _environment.WebRootPath;
                await _productService.SoftDeleteProduct(id, environmentPath);
            }
            catch (ProductIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullProductException ex)
            {
                return NotFound(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Recover(int id)
        {
            try
            {
                string environmentPath = _environment.WebRootPath;
                await _productService.Recover(id, environmentPath);
            }
            catch (ProductIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullProductException ex)
            {
                return NotFound(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var productDetail = await _productService.GetProductDetailById(id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }
    }
}
