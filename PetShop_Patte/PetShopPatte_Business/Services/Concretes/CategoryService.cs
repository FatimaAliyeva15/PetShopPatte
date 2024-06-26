using AutoMapper;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryCreateDTO categoryCreateDTO)
        {
            Category category = _mapper.Map<Category>(categoryCreateDTO);

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
            await _categoryRepository.Recover(id);
            await _categoryRepository.Commit(); 
        }

        public async Task<IQueryable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task HardDeleteCatagory(int id)
        {
            await _categoryRepository.HardDelete(id);
            await _categoryRepository.Commit();

        }

        public async Task SoftDeleteCatagory(int id)
        {
            await _categoryRepository.SoftDelete(id);
            await _categoryRepository.Commit();
        }

        public async Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(categoryUpdateDTO.Id);

            if (existCategory == null)
                throw new NullCategoryException("Category cannot be null");

            await _categoryRepository.UpdateAsync(existCategory);
            await _categoryRepository.Commit();
        }
    }
}
