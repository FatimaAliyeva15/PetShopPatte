﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.DTOs.BasketDTO;
using PetShopPatte_Business.DTOs.BasketItemDTO;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;
using PetShopPatte_Data.Repositories.Abstracts;
using System.Security.Claims;

namespace PetShop_Patte.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basket = await _basketService.GetBasketByUserIdAsync(userId);

            if (basket == null)
            {
                //basket = new BasketGetDTO
                //{
                //    BasketItems = new List<BasketItemGetDTO>()
                //};
            }

            return View(basket);
        }


        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _basketService.AddProductToBasketAsync(userId, productId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromBasket(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _basketService.RemoveProductFromBasketAsync(userId, productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(int productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _basketService.UpdateBasketItemQuantityAsync(userId, productId, quantity);
            return RedirectToAction(nameof(Index));
        }
    }
}

