﻿using Microsoft.AspNetCore.Mvc;

namespace PetShop_Patte.Controllers
{
    public class OurBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
