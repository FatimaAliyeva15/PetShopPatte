using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
