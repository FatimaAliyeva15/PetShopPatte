using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
