using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.DTOs.AnimalTypeDTO;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.Exceptions.AnimalTypeExceptions;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;
using PetShopPatte_Core.Entities.PatteDb;
using EntityNotFoundException = PetShopPatte_Business.Exceptions.AnimalTypeExceptions.EntityNotFoundException;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AnimalTypeController : Controller
    {
        private readonly IAnimalTypeService _animalTypeService;
        private readonly IValidator<AnimalTypeCreateDTO> _validator;
        private readonly IValidator<AnimalTypeUpdateDTO> _updateValidator;

        public AnimalTypeController(IAnimalTypeService animalTypeService, IValidator<AnimalTypeUpdateDTO> updateValidator, IValidator<AnimalTypeCreateDTO> validator)
        {
            _animalTypeService = animalTypeService;
            _updateValidator = updateValidator;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AnimalType> animalTypes = await _animalTypeService.GetAllAnimalTypes();
            return View(animalTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimalTypeCreateDTO animalTypeCreateDTO)
        {
            AnimalTypeCreateDTOValidation validations = new AnimalTypeCreateDTOValidation();
            var validationResult = await _validator.ValidateAsync(animalTypeCreateDTO);

            //var validationResult = await _categoryService.AddCategory(categoryCreateDTO);
            if (!validationResult.IsValid)
            {

                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View(animalTypeCreateDTO);
                }
            }

            await _animalTypeService.AddAnimalType(animalTypeCreateDTO);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var animalTypeUpdateDTO = await _animalTypeService.UpdateById(id);
                return View(animalTypeUpdateDTO);
            }
            catch (AnimalTypeIdNegativeorZeroException ex)
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
        public async Task<IActionResult> Update(AnimalTypeUpdateDTO animalTypeUpdateDTO)
        {
            var validationResult = await _updateValidator.ValidateAsync(animalTypeUpdateDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(animalTypeUpdateDTO);
            }

            await _animalTypeService.UpdateAnimalType(animalTypeUpdateDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var animalType = await _animalTypeService.GetByIdAsync(id);
                if (animalType == null)
                {
                    return NotFound();
                }
                return View(animalType);
            }
            catch (AnimalTypeIdNegativeorZeroException ex)
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
                await _animalTypeService.HardDeleteAnimalType(id);
                return RedirectToAction(nameof(Index));
            }
            catch (AnimalTypeIdNegativeorZeroException ex)
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
                await _animalTypeService.SoftDeleteAnimalType(id);
                return RedirectToAction(nameof(Index));
            }
            catch (AnimalTypeIdNegativeorZeroException ex)
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
                await _animalTypeService.Recover(id);
                return RedirectToAction(nameof(Index));
            }
            catch (CategoryIdNegativeorZeroException ex)
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
