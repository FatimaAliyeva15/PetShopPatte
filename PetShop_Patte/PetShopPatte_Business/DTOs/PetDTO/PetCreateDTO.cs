using FluentValidation;
using Microsoft.AspNetCore.Http;
using PetShopPatte_Business.DTOs.ProductDetailDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.PetDTO
{
    public class PetCreateDTO
    {
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

    public class PetCreateDTOValidation : AbstractValidator<PetCreateDTO>
    {
        public PetCreateDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(100).WithMessage("Name should not exceed 100 characters.");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required").MaximumLength(100).WithMessage("Gender should not exceed 100 characters.");
            RuleFor(x => x.Breed).NotEmpty().WithMessage("Breed is required").MaximumLength(100).WithMessage("Breed should not exceed 100 characters.");
            RuleFor(x => x.ImgFile).NotEmpty().WithMessage("Image is required").Must(BeAValidImage).WithMessage("Invalid image format or size.");
        }

        private bool BeAValidImage(IFormFile imgFile)
        {
            if (imgFile == null)
                return false;

            return imgFile.ContentType.Contains("image/") && imgFile.Length / 1024 / 1024 <= 3; // Validate image type and size
        }
    }
}
