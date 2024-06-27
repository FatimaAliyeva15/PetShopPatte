using FluentValidation;
using PetShopPatte_Business.DTOs.CategoryDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.SubcategoryDTO
{
    public class SubcategoryCreateDTO
    { 
        public string SubcategoryName { get; set; }
        public int? CategoryId { get; set; }
    }

    public class SubcategoryCreateDTOValidation : AbstractValidator<SubcategoryCreateDTO>
    {
        public SubcategoryCreateDTOValidation()
        {
            RuleFor(x => x.SubcategoryName).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
        }
    }
}
