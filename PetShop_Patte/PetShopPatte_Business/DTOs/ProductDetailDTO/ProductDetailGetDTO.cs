using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.ProductDetailDTO
{
    public class ProductDetailGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
        public string ProductName { get; set; }
        public string ImgUrl { get; set; }
    }

    public class ProductDetailGetDTOValidation : AbstractValidator<ProductDetailGetDTO>
    {
        public ProductDetailGetDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Description size can be maximum 500");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.StockQuantity).NotEmpty().WithMessage("StockQuantity is required");

        }
    }

}
