using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.PetDetailDTO
{
    public class PetDetailGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; } // Animal type name
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string ColorName { get; set; } // Color name
        public byte Age { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
    }

    public class PetDetailGetDTOValidation : AbstractValidator<PetDetailGetDTO>
    {
        public PetDetailGetDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Gender size can be maximum 100");
            RuleFor(x => x.Breed).NotEmpty().WithMessage("Breed is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Breed size can be maximum 100");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Description size can be maximum 500");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");
        }
    }
}
