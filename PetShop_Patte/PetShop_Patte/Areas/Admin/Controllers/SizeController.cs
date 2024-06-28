using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.SizeDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Exceptions.SizeExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;
using PetShopPatte_Core.Entities.PatteDb;
using EntityNotFoundException = PetShopPatte_Business.Exceptions.SizeExceptions.EntityNotFoundException;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;
        private readonly IValidator<SizeCreateDTO> _validator;
        private readonly IValidator<SizeUpdateDTO> _updateValidator;

        public SizeController(ISizeService sizeService, IValidator<SizeCreateDTO> validator, IValidator<SizeUpdateDTO> updateValidator)
        {
            _sizeService = sizeService;
            _validator = validator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Size> sizes = await _sizeService.GetAllSizes();
            return View(sizes);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SizeCreateDTO sizeCreateDTO)
        {
            SizeCreateDTOValidation validations = new SizeCreateDTOValidation();
            var validationResult = await _validator.ValidateAsync(sizeCreateDTO);

            //var validationResult = await _categoryService.AddCategory(categoryCreateDTO);
            if (!validationResult.IsValid)
            {

                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View(sizeCreateDTO);
                }
            }

            await _sizeService.AddSize(sizeCreateDTO);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var sizeUpdateDTO = await _sizeService.UpdateById(id);
                return View(sizeUpdateDTO);
            }
            catch (SizeIdNegativeorZeroException ex)
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
        public async Task<IActionResult> Update(SizeUpdateDTO sizeUpdateDTO)
        {
            var validationResult = await _updateValidator.ValidateAsync(sizeUpdateDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(sizeUpdateDTO);
            }

            await _sizeService.UpdateSize(sizeUpdateDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var size = await _sizeService.GetByIdAsync(id);
                if (size == null)
                {
                    return NotFound();
                }
                return View(size);
            }
            catch (SizeIdNegativeorZeroException ex)
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
                await _sizeService.HardDeleteSize(id);
                return RedirectToAction(nameof(Index));
            }
            catch (SizeIdNegativeorZeroException ex)
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
                await _sizeService.SoftDeleteSize(id);
                return RedirectToAction(nameof(Index));
            }
            catch (SizeIdNegativeorZeroException ex)
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
                await _sizeService.Recover(id);
                return RedirectToAction(nameof(Index));
            }
            catch (SizeIdNegativeorZeroException ex)
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
