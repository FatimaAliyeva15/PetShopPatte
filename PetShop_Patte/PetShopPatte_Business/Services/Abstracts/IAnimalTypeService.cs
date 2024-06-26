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
        void AddAnimalType(AnimalTypeCreateDTO animalTypeCreateDTO);
        void UpdateAnimalType(AnimalTypeUpdateDTO animalTypeUpdateDTO);
        void HardDeleteAnimalType(int id);
        void SoftDeleteAnimalType(int id);
        AnimalTypeGetDTO GetAnimalType(Func<AnimalType, bool>? func = null);
        ICollection<AnimalTypeGetDTO> GetAllAnimalTypes(Func<AnimalType, bool>? func = null);
    }
}
