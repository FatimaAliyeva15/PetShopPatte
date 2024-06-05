using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
