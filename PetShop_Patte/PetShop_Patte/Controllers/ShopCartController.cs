using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class ShopCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
