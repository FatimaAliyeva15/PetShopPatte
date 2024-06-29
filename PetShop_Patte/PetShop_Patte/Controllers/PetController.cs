using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.Services.Abstracts;

namespace PetShop_Patte.Controllers
{
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
            return View(pets);
        }
    }
}
