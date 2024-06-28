using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.ColorDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Exceptions.ColorExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;
using PetShopPatte_Core.Entities.PatteDb;
using EntityNotFoundException = PetShopPatte_Business.Exceptions.ColorExceptions.EntityNotFoundException;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        private readonly IValidator<ColorCreateDTO> _validator;
        private readonly IValidator<ColorUpdateDTO> _updateValidator;

        public ColorController(IColorService colorService, IValidator<ColorCreateDTO> validator, IValidator<ColorUpdateDTO> updateValidator)
        {
            _colorService = colorService;
            _validator = validator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Color> colors = await _colorService.GetAllColors();
            return View(colors);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorCreateDTO colorCreateDTO)
        {
            ColorCreateDTOValidation validations = new ColorCreateDTOValidation();
            var validationResult = await _validator.ValidateAsync(colorCreateDTO);

            if (!validationResult.IsValid)
            {

                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View(colorCreateDTO);
                }
            }

            await _colorService.AddColor(colorCreateDTO);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var colorUpdateDTO = await _colorService.UpdateById(id);
                return View(colorUpdateDTO);
            }
            catch (ColorIdNegativeorZeroException ex)
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
        public async Task<IActionResult> Update(ColorUpdateDTO colorUpdateDTO)
        {
            var validationResult = await _updateValidator.ValidateAsync(colorUpdateDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(colorUpdateDTO);
            }

            await _colorService.UpdateColor(colorUpdateDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var color = await _colorService.GetByIdAsync(id);
                if (color == null)
                {
                    return NotFound();
                }
                return View(color);
            }
            catch (ColorIdNegativeorZeroException ex)
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
                await _colorService.HardDeleteColor(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ColorIdNegativeorZeroException ex)
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
                await _colorService.SoftDeleteColor(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ColorIdNegativeorZeroException ex)
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
                await _colorService.Recover(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ColorIdNegativeorZeroException ex)
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
