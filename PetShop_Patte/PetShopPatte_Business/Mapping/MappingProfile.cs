using AutoMapper;
using PetShopPatte_Business.DTOs.AnimalTypeDTO;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.ColorDTO;
using PetShopPatte_Business.DTOs.PetDTO;
using PetShopPatte_Business.DTOs.ProductDTO;
using PetShopPatte_Business.DTOs.SizeDTO;
using PetShopPatte_Business.DTOs.SubcategoryDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetShopPatte_Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AnimalTypeCreateDTO, AnimalType>().ReverseMap();
            CreateMap<AnimalType, AnimalTypeGetDTO>().ReverseMap();
            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
            //CreateMap<Category, CategoryGetDTO>().ReverseMap();
            CreateMap<ColorCreateDTO, Color>().ReverseMap();
            CreateMap<Color, ColorGetDTO>().ReverseMap();
            CreateMap<PetCreateDTO, Pet>().ReverseMap();
            CreateMap<Pet, PetGetDTO>().ReverseMap();
            CreateMap<ProductCreateDTO, Product>().ReverseMap();
            CreateMap<Product, ProductGetDTO>().ReverseMap();
            CreateMap<SizeCreateDTO, Size>().ReverseMap();
            CreateMap<Size, SizeGetDTO>().ReverseMap();
            CreateMap<SubcategoryCreateDTO, Subcategory>().ReverseMap();
            CreateMap<Subcategory, SubcategoryGetDTO>().ReverseMap();
        }
    }
}
