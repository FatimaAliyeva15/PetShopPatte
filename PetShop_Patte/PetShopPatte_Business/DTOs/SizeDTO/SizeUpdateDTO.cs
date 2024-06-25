using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.SizeDTO
{
    public class SizeUpdateDTO
    {
        public int Id { get; set; }       
        public string SizeName { get; set; }
    }

    public class SizeUpdateDTOValidation : AbstractValidator<SizeUpdateDTO>
    {
        public SizeUpdateDTOValidation()
        {
            RuleFor(x => x.SizeName).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
        }
    }
}
