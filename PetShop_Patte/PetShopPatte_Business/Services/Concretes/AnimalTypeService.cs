using AutoMapper;
using PetShopPatte_Business.DTOs.AnimalTypeDTO;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities;
using PetShopPatte_Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Concretes
{
    public class AnimalTypeService : IAnimalTypeService
    {
        private readonly IAnimalTypeRepository _animalTypeRepository;
        private readonly IMapper _mapper;

        public AnimalTypeService(IAnimalTypeRepository animalTypeRepository, IMapper mapper)
        {
            _animalTypeRepository = animalTypeRepository;
            _mapper = mapper;
        }

        public void AddAnimalType(AnimalTypeCreateDTO animalTypeCreateDTO)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AnimalTypeGetDTO> GetAllAnimalTypes()
        {
            throw new NotImplementedException();
        }

        public AnimalTypeGetDTO GetAnimalType(Func<AnimalType, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public void HardDeleteAnimalType(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteAnimalType(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnimalType(AnimalTypeUpdateDTO animalTypeUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
