using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IPetService
    {
        Task AddPet(PetCreateDTO petCreateDTO);
        Task UpdatePet(PetUpdateDTO petUpdateDTO);
        Task<PetUpdateDTO> UpdateById(int id);
        Task HardDeletePet(int id);
        Task SoftDeletePet(int id);
        Task Recover(int id);
        Task<Pet> GetByIdAsync(int id);
        Task<IQueryable<Pet>> GetAllPets();
    }
}
