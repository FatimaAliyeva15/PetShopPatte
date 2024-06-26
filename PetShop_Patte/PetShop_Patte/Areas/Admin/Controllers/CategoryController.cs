using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.PatteDb;

namespace PetShop_Patte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<CategoryCreateDTO> _validator;


        public CategoryController(ICategoryService categoryService, IValidator<CategoryCreateDTO> validator)
        {
            _categoryService = categoryService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories  = await _categoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {
            CategoryCreateDTOValidation validations = new CategoryCreateDTOValidation();
            var validationResult = await _validator.ValidateAsync(categoryCreateDTO);

            //var validationResult = await _categoryService.AddCategory(categoryCreateDTO);
            if (!validationResult.IsValid)
            {
                
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View(categoryCreateDTO);
                }
            }

            await _categoryService.AddCategory(categoryCreateDTO);

            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Update(int id)
        {
            return View();
        }

        //[HttpPost]
        //public Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO)
        //{
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
