using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Core.Entities;
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
        IQueryable<PetGetDTO> GetAllPets();
    }
}
