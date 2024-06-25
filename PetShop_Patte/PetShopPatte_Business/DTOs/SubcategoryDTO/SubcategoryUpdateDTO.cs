using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.SubcategoryDTO
{
    public class SubcategoryUpdateDTO
    {
        public int Id { get; set; }       
        public string SubcategoryName { get; set; }
    }

    public class SubcategoryUpdateDTOValidation : AbstractValidator<SubcategoryUpdateDTO>
    {
        public SubcategoryUpdateDTOValidation()
        {
            RuleFor(x => x.SubcategoryName).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
        }
    }
}
