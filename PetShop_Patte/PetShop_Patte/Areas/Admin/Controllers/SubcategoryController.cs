using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubcategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
