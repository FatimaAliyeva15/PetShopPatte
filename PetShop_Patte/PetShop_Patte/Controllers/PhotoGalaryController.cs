using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class PhotoGalaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
