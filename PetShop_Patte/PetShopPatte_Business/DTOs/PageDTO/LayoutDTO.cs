using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.PageDTO
{
    public class LayoutDTO
    {
        public string? Description { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? LogoUrl { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }

    public class LayoutDTOValidation : AbstractValidator<LayoutDTO>
    {
        public LayoutDTOValidation()
        {
            RuleFor(x => x.Address)
              .MinimumLength(15)
             .MaximumLength(200)
             .WithMessage("Address's length between 15-200 character.");

            RuleFor(x => x.Email)
                .MinimumLength(15)
                .MaximumLength(200)
                .WithMessage("Address's length between 15-200 character.");

            RuleFor(x => x.Description)
                .MinimumLength(25)
                .MaximumLength(200)
                .WithMessage("Description's length between 25-200 character.");

            RuleFor(x => x.Phone)
                .MinimumLength(3)
                .MaximumLength(14)
                .WithMessage("Phone's length between 3-14 character.");
        }
    }
}
