using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Business.Exceptions.PetExceptions;
using PetShopPatte_Business.Services.Abstracts;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IAnimalTypeService _animalTypeService;
        private readonly IColorService _colorService;
        private readonly IValidator<PetCreateDTO> _validator;
        private readonly IValidator<PetUpdateDTO> _updateValidator;
        private readonly IWebHostEnvironment _environment;

        public PetController(IPetService petService, IWebHostEnvironment environment, IValidator<PetCreateDTO> validator, IValidator<PetUpdateDTO> updateValidator, IAnimalTypeService animalTypeService, IColorService colorService)
        {
            _petService = petService;
            _environment = environment;
            _validator = validator;
            _updateValidator = updateValidator;
            _animalTypeService = animalTypeService;
            _colorService = colorService;
        }

        public async Task<IActionResult> Index()
        {
            var pets = await _petService.GetAllPets();
            return View(pets);
        }

        public async Task<IActionResult> Create()
        {
            var animalTypes = await _animalTypeService.GetAllAnimalTypes();
            ViewBag.AnimalTypes = new SelectList(animalTypes, "Id", "Type");

            var color = await _colorService.GetAllColors();
            ViewBag.Colors = new SelectList(color, "Id", "ColorName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PetCreateDTO petCreateDTO)
        {
            PetCreateDTOValidation validations = new PetCreateDTOValidation();
            var validationResult = await _validator.ValidateAsync(petCreateDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(petCreateDTO);
            }

            try
            {
                await _petService.AddPet(_environment.WebRootPath, petCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (PetImageRequiredException ex)
            {
                ModelState.AddModelError("ImgFile", ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ModelState.AddModelError(string.Empty, "Error adding pet.");
            }

            var animalTypes = await _animalTypeService.GetAllAnimalTypes();
            ViewBag.AnimalTypes = new SelectList(animalTypes, "Id", "Type");

            var colors = await _colorService.GetAllColors();
            ViewBag.Colors = new SelectList(colors, "Id", "ColorName");

            return View(petCreateDTO);
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var petUpdateDTO = await _petService.UpdateById(id);
                return View(petUpdateDTO);
            }
            catch (NullPetException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(PetUpdateDTO petUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _petService.UpdatePet(_environment.WebRootPath, petUpdateDTO);
                    return RedirectToAction(nameof(Index));
                }
                catch (PetImageRequiredException ex)
                {
                    ModelState.AddModelError(ex.PropertyName, ex.Message);
                }
            }
            return View(petUpdateDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _petService.GetByIdAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _petService.SoftDeletePet(id);
                return RedirectToAction(nameof(Index));
            }
            catch (PetIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Recover(int id)
        {
            var pet = await _petService.GetByIdAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        [HttpPost, ActionName("Recover")]
        public async Task<IActionResult> RecoverConfirmed(int id)
        {
            try
            {
                await _petService.Recover(id);
                return RedirectToAction(nameof(Index));
            }
            catch (PetIdNegativeorZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
