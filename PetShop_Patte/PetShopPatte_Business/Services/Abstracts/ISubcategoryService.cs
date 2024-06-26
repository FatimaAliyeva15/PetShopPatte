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
        void AddSubcategory(SubcategoryCreateDTO subcategoryCreateDTO);
        void UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO);
        void HardDeleteSubcategory(int id);
        void SoftDeleteSubcategory(int id);
        SubcategoryGetDTO GetSubcategory(Func<Subcategory, bool>? func = null);
        ICollection<SubcategoryGetDTO> GetAllSubcategories(Func<Subcategory, bool>? func = null);
    }
}
