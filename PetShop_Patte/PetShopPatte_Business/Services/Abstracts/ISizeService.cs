using PetShopPatte_Business.DTOs.SizeDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface ISizeService
    {
        Task AddSize(SizeCreateDTO sizeCreateDTO);
        Task UpdateSize(SizeUpdateDTO sizeUpdateDTO);
        Task<SizeUpdateDTO> UpdateById(int id);
        Task HardDeleteSize(int id);
        Task SoftDeleteSize(int id);
        Task Recover(int id);
        Task<Size> GetByIdAsync(int id);
        Task<IQueryable<Size>> GetAllSizes();
    }
}
