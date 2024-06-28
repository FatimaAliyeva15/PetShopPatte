using AutoMapper;
using PetShopPatte_Business.DTOs.AnimalTypeDTO;
using PetShopPatte_Business.Exceptions.AnimalTypeExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities;
using PetShopPatte_Core.Entities.PatteDb;
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

        public AnimalTypeService(IAnimalTypeRepository animalTypeRepository)
        {
            _animalTypeRepository = animalTypeRepository;
        }
        public Task AddAnimalType(AnimalTypeCreateDTO animalTypeCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AnimalType>> GetAllAnimalTypes()
        {
            throw new NotImplementedException();
        }

        public Task<AnimalType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task HardDeleteAnimalType(int id)
        {
            throw new NotImplementedException();
        }

        public Task Recover(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAnimalType(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAnimalType(AnimalTypeUpdateDTO animalTypeUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalTypeUpdateDTO> UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
