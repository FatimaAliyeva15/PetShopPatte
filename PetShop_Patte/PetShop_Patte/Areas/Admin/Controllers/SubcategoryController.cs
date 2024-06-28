using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.SubcategoryDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Exceptions.SubcategoryExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;
using PetShopPatte_Core.Entities.PatteDb;
using EntityNotFoundException = PetShopPatte_Business.Exceptions.SubcategoryExceptions.EntityNotFoundException;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoryService _subcategoryService;
        private readonly IValidator<SubcategoryCreateDTO> _validator;
        private readonly IValidator<SubcategoryUpdateDTO> _updateValidator;

        public SubcategoryController(ISubcategoryService subcategoryService, IValidator<SubcategoryCreateDTO> validator, IValidator<SubcategoryUpdateDTO> updateValidator)
        {
            _subcategoryService = subcategoryService;
            _validator = validator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Subcategory> subcategories = await _subcategoryService.GetAllSubcategories();
            return View(subcategories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubcategoryCreateDTO subcategoryCreateDTO)
        {
            SubcategoryCreateDTOValidation validations = new SubcategoryCreateDTOValidation();
            var validationResult = await _validator.ValidateAsync(subcategoryCreateDTO);

            //var validationResult = await _categoryService.AddCategory(categoryCreateDTO);
            if (!validationResult.IsValid)
            {

                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View(subcategoryCreateDTO);
                }
            }

            await _subcategoryService.AddSubcategory(subcategoryCreateDTO);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var subcategoryUpdateDTO = await _subcategoryService.UpdateById(id);
                return View(subcategoryUpdateDTO);
            }
            catch (SubcategoryIdNegativeorZeroException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubcategoryUpdateDTO subcategoryUpdateDTO)
        {
            var validationResult = await _updateValidator.ValidateAsync(subcategoryUpdateDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(subcategoryUpdateDTO);
            }

            await _subcategoryService.UpdateSubcategory(subcategoryUpdateDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var subcategory = await _subcategoryService.GetByIdAsync(id);
                if (subcategory == null)
                {
                    return NotFound();
                }
                return View(subcategory);
            }
            catch (SubcategoryIdNegativeorZeroException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                await _subcategoryService.HardDeleteSubcatagory(id);
                return RedirectToAction(nameof(Index));
            }
            catch (SubcategoryIdNegativeorZeroException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _subcategoryService.SoftDeleteSubcatagory(id);
                return RedirectToAction(nameof(Index));
            }
            catch (SubcategoryIdNegativeorZeroException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Recover(int id)
        {
            try
            {
                await _subcategoryService.Recover(id);
                return RedirectToAction(nameof(Index));
            }
            catch (SubcategoryIdNegativeorZeroException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
