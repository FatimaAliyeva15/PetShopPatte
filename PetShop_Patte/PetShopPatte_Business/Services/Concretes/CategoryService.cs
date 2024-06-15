using AutoMapper;
using PetShopPatte_Business.DTOs.CategoryDTO;
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
            throw new NotImplementedException();
        }

        public IQueryable<CategoryGetDTO> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public CategoryGetDTO GetCategory(Func<Category, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public void HardDeleteCatagory(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteCatagory(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
