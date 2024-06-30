using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.ProductDTO
{
    public class ProductGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? SubcategoryId { get; set; }
        public int? AnimalTypeId { get; set; }
        public IFormFile ImgFile { get; set; }
    }

    public class ProductGetDTOValidation : AbstractValidator<ProductGetDTO>
    {
        public ProductGetDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required").WithMessage("Price is required");
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
