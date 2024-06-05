using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
