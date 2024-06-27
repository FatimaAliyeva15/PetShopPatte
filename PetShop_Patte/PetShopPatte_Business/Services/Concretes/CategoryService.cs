using AutoMapper;
using FluentValidation;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryUpdateDTO> _updatevalidator;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CategoryUpdateDTO> updatevalidator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _updatevalidator = updatevalidator;
        }

        public async Task AddCategory(CategoryCreateDTO categoryCreateDTO)
        {
            //Category category = _mapper.Map<Category>(categoryCreateDTO);
            Category category = new Category()
            {
                CategoryName = categoryCreateDTO.CategoryName,
                CategoryIcon = categoryCreateDTO.CategoryIcon,
            };

            if (category == null)
                throw new NullCategoryException("Category cannot be null");

            var categories = await _categoryRepository.GetAllAsync();

            if (!categories.Any(x => x.CategoryName == category.CategoryName))
            {
                await _categoryRepository.AddAsync(category);
                await _categoryRepository.Commit();
            }
            else
            {
                throw new DuplicateCategoryException("CategoryName", "Category name cannot be the same");
            }
        }

        public async Task Recover(int id)
        {
            if (id <= 0)
                throw new CategoryIdNegativeorZeroException("Category id not negative and zero");

            await _categoryRepository.Recover(id);
            await _categoryRepository.Commit(); 
        }

        public async Task<IQueryable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new CategoryIdNegativeorZeroException("Category id not negative and zero");

            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task HardDeleteCatagory(int id)
        {
            if (id <= 0)
                throw new CategoryIdNegativeorZeroException("Category id not negative and zero");

            await _categoryRepository.HardDelete(id);
            await _categoryRepository.Commit();

        }

        public async Task SoftDeleteCatagory(int id)
        {
            if (id <= 0)
                throw new CategoryIdNegativeorZeroException("Category id not negative and zero");

            await _categoryRepository.SoftDelete(id);
            await _categoryRepository.Commit();
        }

        public async Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(categoryUpdateDTO.Id);

            if (existCategory == null)
                throw new NullCategoryException("Category cannot be null");

            existCategory.CategoryName = categoryUpdateDTO.CategoryName ?? existCategory.CategoryName;
            existCategory.CategoryIcon = categoryUpdateDTO.CategoryIcon ?? existCategory.CategoryIcon;
            existCategory.ParentCategoryId = categoryUpdateDTO.ParentCategoryId ?? existCategory.ParentCategoryId;

             _categoryRepository.Update(existCategory);
            await _categoryRepository.Commit();
        }

        

        public async Task<CategoryUpdateDTO> UpdateById(int id)
        {
            if (id <= 0) 
                throw new CategoryIdNegativeorZeroException("Category id not negative and zero");

            if (await _categoryRepository.IsExists(id))
            {

                var category = await _categoryRepository.GetByIdAsync(id);

                CategoryUpdateDTO categoryUpdateDTO = new CategoryUpdateDTO()
                {
                    CategoryName = category.CategoryName,
                    CategoryIcon = category.CategoryIcon,
                };

                return categoryUpdateDTO;
            }
            else
            {
                throw new EntityNotFoundException("", "Entity not found");
            }
        }


    }
}
