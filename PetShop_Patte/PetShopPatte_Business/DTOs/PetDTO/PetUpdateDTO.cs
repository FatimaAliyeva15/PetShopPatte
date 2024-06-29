using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.PetDTO
{
    public class PetUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public decimal Price { get; set; }

        public string Gender { get; set; }

        public string Breed { get; set; }
        public int? TypeId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public IFormFile ImgFile { get; set; }
    }

    public class PetUpdateDTOValidation : AbstractValidator<PetUpdateDTO>
    {
        public PetUpdateDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required")
                                 .GreaterThan(0).WithMessage("Price must be greater than zero");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Gender size can be maximum 100");
            RuleFor(x => x.Breed).NotEmpty().WithMessage("Breed is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Breed size can be maximum 100");
        }
    }
}
