using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.CategoryDTO
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryIcon { get; set; }
    }

    public class CategoryUpdateDTOValidation : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateDTOValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
        }
    }
}
