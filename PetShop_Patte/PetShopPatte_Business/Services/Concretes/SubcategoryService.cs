using AutoMapper;
using PetShopPatte_Business.DTOs.SubcategoryDTO;
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
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        public void AddSubcategory(SubcategoryCreateDTO subcategoryCreateDTO)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubcategoryGetDTO> GetAllSubcategories()
        {
            throw new NotImplementedException();
        }

        public SubcategoryGetDTO GetSubcategory(Func<Subcategory, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public void HardDeleteSubcategory(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteSubcategory(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
