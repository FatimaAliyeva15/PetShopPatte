using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class OurProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
