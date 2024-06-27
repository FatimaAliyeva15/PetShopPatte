using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        public async Task<IActionResult> Index()
        {
            var pets = await _petService.GetAllPets();
            return View(pets.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PetCreateDTO petCreateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _petService.AddPet(petCreateDTO);
                    return RedirectToAction(nameof(Index));
                }
                catch (PetImageRequiredException ex)
                {
                    ModelState.AddModelError(ex.PropertyName, ex.Message);
                }
            }
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
                    await _petService.UpdatePet(petUpdateDTO);
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
