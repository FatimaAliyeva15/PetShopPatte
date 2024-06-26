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
        void AddPet(PetCreateDTO petCreateDTO);
        void UpdatePet(PetUpdateDTO petUpdateDTO);
        void HardDeletePet(int id);
        void SoftDeletePet(int id); 
        PetGetDTO GetPet(Func<Pet, bool>? func = null);
        ICollection<PetGetDTO> GetAllPets(Func<Pet, bool>? func = null);
    }
}
