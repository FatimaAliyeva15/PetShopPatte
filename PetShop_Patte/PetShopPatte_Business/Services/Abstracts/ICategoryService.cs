using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryCreateDTO categoryCreateDTO);
        Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);
        Task HardDeleteCatagory(int id);
        Task SoftDeleteCatagory(int id);
        Task DeleteDb(int id);
        Task<Category> GetByIdAsync(int id);
        Task<IQueryable<Category>> GetAllCategories();
    }
}
