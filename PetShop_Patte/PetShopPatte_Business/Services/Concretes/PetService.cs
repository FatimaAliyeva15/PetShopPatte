using AutoMapper;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Concretes
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PetService(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public void AddPet(PetCreateDTO petCreateDTO)
        {
            throw new NotImplementedException();
        }

        public ICollection<PetGetDTO> GetAllPets(Func<Pet, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public PetGetDTO GetPet(Func<Pet, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public void HardDeletePet(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeletePet(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePet(PetUpdateDTO petUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
