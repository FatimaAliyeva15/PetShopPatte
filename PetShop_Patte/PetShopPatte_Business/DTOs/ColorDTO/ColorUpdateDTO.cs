using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.ColorDTO
{
    public class ColorUpdateDTO
    {
        public int Id {  get; set; }        
        public string ColorName { get; set; }
    }

    public class ColorUpdateDTOValidation : AbstractValidator<ColorUpdateDTO>
    {
        public ColorUpdateDTOValidation()
        {
            RuleFor(x => x.ColorName).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
        }
    }
}
