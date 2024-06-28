using PetShopPatte_Business.DTOs.AnimalTypeDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IAnimalTypeService
    {
        Task AddAnimalType(AnimalTypeCreateDTO animalTypeCreateDTO);
        Task UpdateAnimalType(AnimalTypeUpdateDTO animalTypeUpdateDTO);
        Task<AnimalTypeUpdateDTO> UpdateById(int id);
        Task HardDeleteAnimalType(int id);
        Task SoftDeleteAnimalType(int id);
        Task Recover(int id);
        Task<AnimalType> GetByIdAsync(int id);
        Task<IQueryable<AnimalType>> GetAllAnimalTypes();
    }
}
