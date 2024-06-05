using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class HowWeWorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
