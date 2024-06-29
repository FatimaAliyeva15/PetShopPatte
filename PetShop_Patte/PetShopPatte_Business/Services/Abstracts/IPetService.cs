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
        Task AddPet(string environmet, PetCreateDTO petCreateDTO);
        Task UpdatePet(string environmet, PetUpdateDTO petUpdateDTO);
        Task<PetUpdateDTO> UpdateById(int id);
        Task HardDeletePet(int id, string environment);
        Task SoftDeletePet(int id, string environment);
        Task Recover(int id, string environment);
        Task<Pet> GetByIdAsync(int id);
        Task<IQueryable<Pet>> GetAllPets();
        Task<PetDetail> GetPetDetailById(int id);
    }
}
