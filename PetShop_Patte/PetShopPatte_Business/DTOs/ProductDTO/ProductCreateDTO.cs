using FluentValidation;
using Microsoft.AspNetCore.Http;
using PetShopPatte_Business.DTOs.ColorDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.ProductDTO
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public int? SubcategoryId { get; set; }
        public int? AnimalTypeId { get; set; }
        public IFormFile ImgFile { get; set; }
    }

    public class ProductCreateDTOValidation : AbstractValidator<ProductCreateDTO>
    {
        public ProductCreateDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
        }
    }

}
