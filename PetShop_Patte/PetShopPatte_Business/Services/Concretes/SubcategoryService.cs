using FluentValidation;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.SubcategoryDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Exceptions.SubcategoryExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.Repositories.Abstracts;
using PetShopPatte_Data.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityNotFoundException = PetShopPatte_Business.Exceptions.SubcategoryExceptions.EntityNotFoundException;

namespace PetShopPatte_Business.Services.Concretes
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IValidator<SubcategoryUpdateDTO> _validator;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository, IValidator<SubcategoryUpdateDTO> validator)
        {
            _subcategoryRepository = subcategoryRepository;
            _validator = validator;
        }

        public async Task AddSubcategory(SubcategoryCreateDTO subcategoryCreateDTO)
        {
            Subcategory subcategory = new Subcategory()
            {
                SubcategoryName = subcategoryCreateDTO.SubcategoryName,
                CategoryId = subcategoryCreateDTO.CategoryId,
            };

            if (subcategory == null)
                throw new NullSubcategoryException("Subcategory cannot be null");

            var subcategories = await _subcategoryRepository.GetAllAsync();

            if (!subcategories.Any(x => x.SubcategoryName == subcategory.SubcategoryName))
            {
                await _subcategoryRepository.AddAsync(subcategory);
                await _subcategoryRepository.Commit();
            }
            else
            {
                throw new DuplicateSubcategoryException("SubcategoryName", "Subcategory name cannot be the same");
            }
        }

        public async Task<IQueryable<Subcategory>> GetAllSubcategories()
        {
            return await _subcategoryRepository.GetAllAsync();
        }

        public async Task<Subcategory> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new SubcategoryIdNegativeorZeroException("Subcategory id not negative and zero");

            return await _subcategoryRepository.GetByIdAsync(id);
        }

        public async Task HardDeleteSubcatagory(int id)
        {
            if (id <= 0)
                throw new SubcategoryIdNegativeorZeroException("Subcategory id not negative and zero");

            await _subcategoryRepository.HardDelete(id);
            await _subcategoryRepository.Commit();
        }

        public async Task Recover(int id)
        {
            if (id <= 0)
                throw new SubcategoryIdNegativeorZeroException("Subcategory id not negative and zero");

            await _subcategoryRepository.Recover(id);
            await _subcategoryRepository.Commit();
        }

        public async Task SoftDeleteSubcatagory(int id)
        {
            if (id <= 0)
                throw new SubcategoryIdNegativeorZeroException("Subcategory id not negative and zero");

            await _subcategoryRepository.SoftDelete(id);
            await _subcategoryRepository.Commit();
        }

        public async Task<SubcategoryUpdateDTO> UpdateById(int id)
        {
            if (id <= 0)
                throw new SubcategoryIdNegativeorZeroException("Subcategory id not negative and zero");

            if (await _subcategoryRepository.IsExists(id))
            {

                var subcategory = await _subcategoryRepository.GetByIdAsync(id);

                SubcategoryUpdateDTO subcategoryUpdateDTO = new SubcategoryUpdateDTO()
                {
                    SubcategoryName = subcategory.SubcategoryName,
                    CategoryId = subcategory.CategoryId,
                };

                return subcategoryUpdateDTO;
            }
            else
            {
                throw new EntityNotFoundException("", "Entity not found");
            }

        }

        public async Task UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO)
        {
            var existSubcategory = await _subcategoryRepository.GetByIdAsync(subcategoryUpdateDTO.Id);

            if (existSubcategory == null)
                throw new NullCategoryException("Category cannot be null");

            existSubcategory.SubcategoryName = subcategoryUpdateDTO.SubcategoryName ?? existSubcategory.SubcategoryName;
            existSubcategory.CategoryId = subcategoryUpdateDTO.CategoryId ?? existSubcategory.CategoryId;

            _subcategoryRepository.Update(existSubcategory);
            await _subcategoryRepository.Commit();
        }
    }
}
