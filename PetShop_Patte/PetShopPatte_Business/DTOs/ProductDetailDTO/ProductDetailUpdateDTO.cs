using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.ProductDetailDTO
{
    public class ProductDetailUpdateDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
        public int? ProductId { get; set; }
        public IFormFile? ImgFile { get; set; }
    }

    public class ProductDetailUpdateDTOValidation : AbstractValidator<ProductDetailUpdateDTO>
    {
        public ProductDetailUpdateDTOValidation()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.StockQuantity).NotEmpty().WithMessage("StockQuantity is required");

        }
    }
}
