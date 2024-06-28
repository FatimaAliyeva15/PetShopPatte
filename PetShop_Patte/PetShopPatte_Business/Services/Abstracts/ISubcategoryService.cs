using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.SubcategoryDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface ISubcategoryService
    {
        Task AddSubcategory(SubcategoryCreateDTO subcategoryCreateDTO);
        Task UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO);
        Task<SubcategoryUpdateDTO> UpdateById(int id);
        Task HardDeleteSubcatagory(int id);
        Task SoftDeleteSubcatagory(int id);
        Task Recover(int id);
        Task<Subcategory> GetByIdAsync(int id);
        Task<IQueryable<Subcategory>> GetAllSubcategories();
    }
}
