//using AutoMapper;
//using PetShopPatte_Business.DTOs.AnimalTypeDTO;
//using PetShopPatte_Business.Exceptions.AnimalTypeExceptions;
//using PetShopPatte_Business.Services.Abstracts;
//using PetShopPatte_Core.Entities;
//using PetShopPatte_Data.Repositories.Abstracts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PetShopPatte_Business.Services.Concretes
//{
//    public class AnimalTypeService : IAnimalTypeService
//    {
//        private readonly IAnimalTypeRepository _animalTypeRepository;
//        private readonly IMapper _mapper;

//        public AnimalTypeService(IAnimalTypeRepository animalTypeRepository, IMapper mapper)
//        {
//            _animalTypeRepository = animalTypeRepository;
//            _mapper = mapper;
//        }

//        public void AddAnimalType(AnimalTypeCreateDTO animalTypeCreateDTO)
//        {
//            AnimalType animalType = _mapper.Map<AnimalType>(animalTypeCreateDTO);

//            if (animalType == null)
//                throw new NullAnimalTypeException("Animal type cannot be null");

//            if(!_animalTypeRepository.GetAll().Any(x => x.Type == animalType.Type))
//            {
//                _animalTypeRepository.Add(animalType);
//                _animalTypeRepository.Commit();
//            }
//            else
//            {
//                throw new DuplicateAnimalTypeException("Type", "Animal type cannot be the same");
//            }
//        }

//        public ICollection<AnimalTypeGetDTO> GetAllAnimalTypes(Func<AnimalType, bool>? func = null)
//        {
//            var animalTypes = _animalTypeRepository.GetAll(func);

//            ICollection<AnimalTypeGetDTO> animalTypeGetDTOs = new List<AnimalTypeGetDTO>();

//            foreach(var animalType in animalTypes)
//            {
//                AnimalTypeGetDTO animalTypeGetDTO = new AnimalTypeGetDTO()
//                {
//                    Id = animalType.Id,
//                    Type = animalType.Type,
//                };

//                animalTypeGetDTOs.Add(animalTypeGetDTO);
//            }

//            return animalTypeGetDTOs;
//        }

//        public AnimalTypeGetDTO GetAnimalType(Func<AnimalType, bool>? func = null)
//        {
//            var animalType = _animalTypeRepository.Get(func);

//            AnimalTypeGetDTO animalTypeGetDTO = _mapper.Map<AnimalTypeGetDTO>(animalType);
//            return animalTypeGetDTO;
//        }

//        public void HardDeleteAnimalType(int id)
//        {
//            var existType = _animalTypeRepository.Get(x => x.Id == id);

//            if(existType == null)
//                throw new NullAnimalTypeException("Animal type cannot be null");

//            _animalTypeRepository.HardDelete(existType);
//            _animalTypeRepository.Commit();
//        }

//        public void SoftDeleteAnimalType(int id)
//        {
//            var existType = _animalTypeRepository.Get(x => x.Id == id);

//            if (existType == null)
//                throw new NullAnimalTypeException("Animal type cannot be null");

//            _animalTypeRepository.SoftDelete(existType);
//            _animalTypeRepository.Commit();
//        }

//        public void UpdateAnimalType(AnimalTypeUpdateDTO animalTypeUpdateDTO)
//        {
//            var animalType = _animalTypeRepository.Get(x => x.Id == animalTypeUpdateDTO.Id);

//            if (animalType == null)
//                throw new NullAnimalTypeException("Animal type cannot be null");

//            animalType.Type = animalTypeUpdateDTO.Type;
//            _animalTypeRepository.Commit();
//        }
//    }
//}
