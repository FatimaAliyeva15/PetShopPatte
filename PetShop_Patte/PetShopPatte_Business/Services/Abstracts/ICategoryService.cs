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
        void AddCategory(CategoryCreateDTO categoryCreateDTO);
        void UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);
        void HardDeleteCatagory(int id);
        void SoftDeleteCatagory(int id);
        CategoryGetDTO GetCategory(Func<Category, bool>? func = null);
        IQueryable<CategoryGetDTO> GetAllCategories();
    }
}
