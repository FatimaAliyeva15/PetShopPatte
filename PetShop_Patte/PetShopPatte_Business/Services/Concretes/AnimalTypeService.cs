using AutoMapper;
using FluentValidation;
using PetShopPatte_Business.DTOs.AnimalTypeDTO;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.Exceptions.AnimalTypeExceptions;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.Repositories.Abstracts;
using PetShopPatte_Data.Repositories.Concretes;
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
        private readonly IValidator<AnimalTypeUpdateDTO> _validator;

        public AnimalTypeService(IAnimalTypeRepository animalTypeRepository)
        {
            _animalTypeRepository = animalTypeRepository;
        }
        public async Task AddAnimalType(AnimalTypeCreateDTO animalTypeCreateDTO)
        {
            AnimalType animalType = new AnimalType()
            {
                Type = animalTypeCreateDTO.Type,
            };

            if(animalType == null )
                throw new NullAnimalTypeException("Animal type cannot be null");

            var animalTypes = await _animalTypeRepository.GetAllAsync();

            if (!animalTypes.Any(x => x.Type == animalType.Type))
            {
                await _animalTypeRepository.AddAsync(animalType);
                await _animalTypeRepository.Commit();
            }
            else
            {
                throw new DuplicateAnimalTypeException("Type", "Animal type cannot be the same");
            }
        }

        public async Task<IQueryable<AnimalType>> GetAllAnimalTypes()
        {
            return await _animalTypeRepository.GetAllAsync();
        }

        public async Task<AnimalType> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new AnimalTypeIdNegativeorZeroException("Animal type id not negative and zero");

            return await _animalTypeRepository.GetByIdAsync(id);
        }

        public async Task HardDeleteAnimalType(int id)
        {
            if (id <= 0)
                throw new AnimalTypeIdNegativeorZeroException("Animal type id not negative and zero");

            await _animalTypeRepository.HardDelete(id);
        }

        public async Task Recover(int id)
        {
            if (id <= 0)
                throw new AnimalTypeIdNegativeorZeroException("Animal type id not negative and zero");

            await _animalTypeRepository.Recover(id);
        }

        public async Task SoftDeleteAnimalType(int id)
        {
            if (id <= 0)
                throw new AnimalTypeIdNegativeorZeroException("Animal type id not negative and zero");

            await _animalTypeRepository.SoftDelete(id);
        }

        public async Task UpdateAnimalType(AnimalTypeUpdateDTO animalTypeUpdateDTO)
        {
            var existType = await _animalTypeRepository.GetByIdAsync(animalTypeUpdateDTO.Id);

            if (existType == null)
                throw new NullAnimalTypeException("Animal type cannot be null");

            existType.Type = animalTypeUpdateDTO.Type ?? existType.Type;

            _animalTypeRepository.Update(existType);
            await _animalTypeRepository.Commit();
        }

        public async Task<AnimalTypeUpdateDTO> UpdateById(int id)
        {
            if (id <= 0)
                throw new AnimalTypeIdNegativeorZeroException("Animal type id not negative and zero");

            if (await _animalTypeRepository.IsExists(id))
            {

                var animalType = await _animalTypeRepository.GetByIdAsync(id);

                AnimalTypeUpdateDTO animalTypeUpdateDTO = new AnimalTypeUpdateDTO()
                {
                    Type = animalType.Type,
                };

                return animalTypeUpdateDTO;
            }
            else
            {
                throw new Exceptions.AnimalTypeExceptions.EntityNotFoundException("", "Entity not found");
            }
        }
    }
}
