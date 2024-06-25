using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.CategoryDTO
{
    public class CategoryCreateDTO
    {
        public string CategoryName { get; set; }
    }

    public class CategoryCreateDTOValidation : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateDTOValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
        }
    }
}


