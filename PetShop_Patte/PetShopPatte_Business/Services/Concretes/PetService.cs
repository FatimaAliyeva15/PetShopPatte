using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Exceptions.PetExceptions;
using PetShopPatte_Business.Helpers;
using PetShopPatte_Business.Services.Abstracts;
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
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        //private readonly string _enviroment;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
            //_environment = enviroment;
        }

        public async Task AddPet(string environment, PetCreateDTO petCreateDTO)
        {
            if (petCreateDTO.ImgFile != null && petCreateDTO.ImgFile.CheckImgFile())
            {
                // Ensure the environment path is correct and ends with a directory separator
                string webRootPath = Path.Combine(environment, "PetImages");

                // Save image to the specified folder
                string imgPath = petCreateDTO.ImgFile.AddImage(webRootPath, "");

                Pet pet = new Pet
                {
                    Name = petCreateDTO.Name,
                    Age = petCreateDTO.Age,
                    Gender = petCreateDTO.Gender,
                    Breed = petCreateDTO.Breed,
                    TypeId = petCreateDTO.TypeId,
                    ColorId = petCreateDTO.ColorId,
                    SizeId = petCreateDTO.SizeId,
                    ImgUrl = imgPath,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                };

                await _petRepository.AddAsync(pet);
                await _petRepository.Commit();
            }
            else
            {
                throw new PetImageRequiredException("ImgFile", "Image is required");
            }
        }


        public async Task UpdatePet(string environment, PetUpdateDTO petUpdateDTO)
        {
            var existPet = await _petRepository.GetByIdAsync(petUpdateDTO.Id);

            if (existPet != null && !existPet.IsDeleted)
            {
                existPet.Name = petUpdateDTO.Name;
                existPet.Age = petUpdateDTO.Age;
                existPet.Gender = petUpdateDTO.Gender;
                existPet.Breed = petUpdateDTO.Breed;
                existPet.TypeId = petUpdateDTO.TypeId;
                existPet.ColorId = petUpdateDTO.ColorId;
                existPet.SizeId = petUpdateDTO.SizeId;
                existPet.UpdatedDate = DateTime.UtcNow;

                if (petUpdateDTO.ImgFile != null && petUpdateDTO.ImgFile.CheckImgFile())
                {
                    string imgPath = petUpdateDTO.ImgFile.UpdateImage(environment, "PetImages/");
                    if (!string.IsNullOrEmpty(existPet.ImgUrl))
                    {
                        existPet.ImgUrl.DeleteImage(environment, "PetImages/");
                    }
                    existPet.ImgUrl = imgPath;
                }
                else
                {
                    throw new PetImageRequiredException("ImgFile", "Image is required");
                }

                _petRepository.Update(existPet);
                await _petRepository.Commit();
            }

        }

        public async Task<PetUpdateDTO> UpdateById(int id)
        {
            var existPet = await _petRepository.GetByIdAsync(id);

            if (existPet != null && !existPet.IsDeleted)
            {
                return new PetUpdateDTO
                {
                    Id = existPet.Id,
                    Name = existPet.Name,
                    Age = existPet.Age,
                    Gender = existPet.Gender,
                    Breed = existPet.Breed,
                    TypeId = existPet.TypeId,
                    ColorId = existPet.ColorId,
                    SizeId = existPet.SizeId,
                    ImgFile = null // ImgFile cannot be assigned directly, typically set via a view form
                };
            }
            else
            {
                throw new NullPetException("Pet cannot be null");
            }
        }

        public async Task HardDeletePet(int id, string environment)
        {
            if (id <= 0)
                throw new PetIdNegativeorZeroException("Pet id not negative and zero");

            var pet = await _petRepository.GetByIdAsync(id);

            if (pet == null || pet.IsDeleted)
            {
                throw new NullPetException("Pet cannot be null or already deleted.");
            }

            // Delete the image
            if (!string.IsNullOrEmpty(pet.ImgUrl))
            {
                pet.ImgUrl.DeleteImage(environment, "PetImages/");
            }

            await _petRepository.HardDelete(id);
            await _petRepository.Commit();
        }

        public async Task SoftDeletePet(int id, string environment)
        {
            if (id <= 0)
                throw new PetIdNegativeorZeroException("Pet id not negative and zero");

            var pet = await _petRepository.GetByIdAsync(id);

            if (pet == null || pet.IsDeleted)
            {
                throw new NullPetException("Pet cannot be null or already deleted.");
            }

            // Delete the image
            if (!string.IsNullOrEmpty(pet.ImgUrl))
            {
                pet.ImgUrl.DeleteImage(environment, "PetImages/");
            }

            await _petRepository.SoftDelete(id);
            await _petRepository.Commit();
        }

        public async Task Recover(int id, string environment)
        {
            if (id <= 0)
                throw new PetIdNegativeorZeroException("Pet id not negative and zero");

            var pet = await _petRepository.GetByIdAsync(id);

            if (pet == null || pet.IsDeleted)
            {
                throw new NullPetException("Pet cannot be null or already deleted.");
            }

            // Delete the image
            if (!string.IsNullOrEmpty(pet.ImgUrl))
            {
                pet.ImgUrl.DeleteImage(environment, "PetImages/");
            }


            await _petRepository.Recover(id);
            await _petRepository.Commit();
        }

        public async Task<Pet> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new PetIdNegativeorZeroException("Pet id not negative and zero");

            return await _petRepository.GetByIdAsync(id);
        }

        public async Task<IQueryable<Pet>> GetAllPets()
        {
            return await _petRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public async Task<PetDetail> GetPetDetailById(int id)
        {
            return await _petRepository.GetPetDetailByIdAsync(id);
        }
    }
}
