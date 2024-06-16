using AutoMapper;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void AddCategory(CategoryCreateDTO categoryCreateDTO)
        {
            Category category = _mapper.Map<Category>(categoryCreateDTO);

            if (category == null) 
                throw new NullCategoryException("Category cannot be null");

            if (!_categoryRepository.GetAll().Any(x => x.CategoryName == category.CategoryName))
            {
                _categoryRepository.Add(category);
                _categoryRepository.Commit();
            }
            else
            {
                throw new DuplicateCategoryException("CategoryName", "Category name cannot be the same");
            }
        }

        public ICollection<CategoryGetDTO> GetAllCategories(Func<Category, bool>? func = null)
        {
            var categories = _categoryRepository.GetAll(func);

            ICollection<CategoryGetDTO> categoryGetDTOs = new List<CategoryGetDTO>();

            foreach (var category in categories)
            {
                CategoryGetDTO categoryGetDTO = new CategoryGetDTO()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                };

                categoryGetDTOs.Add(categoryGetDTO);
            }

            return categoryGetDTOs;
        }

        public CategoryGetDTO GetCategory(Func<Category, bool>? func = null)
        {
            var category = _categoryRepository.Get(func);

            CategoryGetDTO categoryGetDTO = _mapper.Map<CategoryGetDTO>(category);
            return categoryGetDTO;
        }

        public void HardDeleteCatagory(int id)
        {
            var existCategory = _categoryRepository.Get(x => x.Id == id);

            if (existCategory == null)
                throw new NullCategoryException("Category cannot be null");

            _categoryRepository.HardDelete(existCategory);
            _categoryRepository.Commit();
        }

        public void SoftDeleteCatagory(int id)
        {
            var existCategory = _categoryRepository.Get(x => x.Id == id);

            if (existCategory == null)
                throw new NullCategoryException("Category cannot be null");

            _categoryRepository.SoftDelete(existCategory);
            _categoryRepository.Commit();
        }

        public void UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var existCategory = _categoryRepository.Get(x => x.Id == categoryUpdateDTO.Id);

            if (existCategory == null)
                throw new NullCategoryException("Category cannot be null");

            existCategory.CategoryName = categoryUpdateDTO.CategoryName;
            _categoryRepository.Commit();
        }
    }
}
