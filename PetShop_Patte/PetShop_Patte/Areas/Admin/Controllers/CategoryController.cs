using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
