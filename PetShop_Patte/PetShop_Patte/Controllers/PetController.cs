using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
