using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PetShop_Patte.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
