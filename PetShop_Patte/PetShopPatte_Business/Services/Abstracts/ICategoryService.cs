using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryCreateDTO categoryCreateDTO);
        Task<ValidationResult> UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);
        Task<CategoryUpdateDTO> UpdateById(int id);
        Task HardDeleteCatagory(int id);
        Task SoftDeleteCatagory(int id);
        Task Recover(int id);
        Task<Category> GetByIdAsync(int id);
        Task<IQueryable<Category>> GetAllCategories();
    }
}
