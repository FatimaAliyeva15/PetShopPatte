//using AutoMapper;
//using PetShopPatte_Business.DTOs.SubcategoryDTO;
//using PetShopPatte_Business.Exceptions.SubcategoryExceptions;
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
//    public class SubcategoryService : ISubcategoryService
//    {
//        private readonly ISubcategoryRepository _subcategoryRepository;
//        private readonly IMapper _mapper;

//        public SubcategoryService(ISubcategoryRepository subcategoryRepository, IMapper mapper)
//        {
//            _subcategoryRepository = subcategoryRepository;
//            _mapper = mapper;
//        }

//        public void AddSubcategory(SubcategoryCreateDTO subcategoryCreateDTO)
//        {
//            Subcategory subcategory = _mapper.Map<Subcategory>(subcategoryCreateDTO);

//            if (subcategory == null)
//                throw new NullSubcategoryException("Subcategory cannot be null");

//            if(!_subcategoryRepository.GetAll().Any(x => x.SubcategoryName == subcategory.SubcategoryName))
//            {
//                _subcategoryRepository.Add(subcategory);
//                _subcategoryRepository.Commit();
//            }
//            else
//            {
//                throw new DuplicateSubcategoryException("SubcategoryName", "Subcategory name cannot be the same");
//            }
//        }

//        public ICollection<SubcategoryGetDTO> GetAllSubcategories(Func<Subcategory, bool>? func = null)
//        {
//            var subcategories = _subcategoryRepository.GetAll(func);

//            ICollection<SubcategoryGetDTO> subcategoryGetDTOs = new List<SubcategoryGetDTO>();

//            foreach (var subcategory in subcategories)
//            {
//                SubcategoryGetDTO subcategoryGetDTO = new SubcategoryGetDTO()
//                {
//                    Id = subcategory.Id,
//                    SubcategoryName = subcategory.SubcategoryName,
//                };

//                subcategoryGetDTOs.Add(subcategoryGetDTO);
//            }
//            return subcategoryGetDTOs;
//        }

//        public SubcategoryGetDTO GetSubcategory(Func<Subcategory, bool>? func = null)
//        {
//            var subcategory = _subcategoryRepository.Get(func);

//            SubcategoryGetDTO subcategoryGetDTO = _mapper.Map<SubcategoryGetDTO>(subcategory);
//            return subcategoryGetDTO;
//        }

//        public void HardDeleteSubcategory(int id)
//        {
//            var existSubcategory = _subcategoryRepository.Get(x => x.Id == id);

//            if (existSubcategory == null)
//                throw new NullSubcategoryException("Subcategory cannot be null"); 

//            _subcategoryRepository.HardDelete(existSubcategory);
//            _subcategoryRepository.Commit();
//        }

//        public void SoftDeleteSubcategory(int id)
//        {
//            var existSubcategory = _subcategoryRepository.Get(x => x.Id == id);

//            if (existSubcategory == null)
//                throw new NullSubcategoryException("Subcategory cannot be null");

//            _subcategoryRepository.SoftDelete(existSubcategory);
//            _subcategoryRepository.Commit();
//        }

//        public void UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO)
//        {
//            var existSubcategory = _subcategoryRepository.Get(x => x.Id == subcategoryUpdateDTO.Id);

//            if (existSubcategory == null)
//                throw new NullSubcategoryException("Subcategory cannot be null");

//            existSubcategory.SubcategoryName = subcategoryUpdateDTO.SubcategoryName;
//            _subcategoryRepository.Commit();
//        }
//    }
//}
