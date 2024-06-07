using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class CartCheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
