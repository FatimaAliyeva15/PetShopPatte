using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.ColorDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IColorService
    {
        Task AddColor(ColorCreateDTO colorCreateDTO);
        Task UpdateColor(ColorUpdateDTO colorUpdateDTO);
        Task<ColorUpdateDTO> UpdateById(int id);
        Task HardDeleteColor(int id);
        Task SoftDeleteColor(int id);
        Task Recover(int id);
        Task<Color> GetByIdAsync(int id);
        Task<IQueryable<Color>> GetAllColors();
    }
}
