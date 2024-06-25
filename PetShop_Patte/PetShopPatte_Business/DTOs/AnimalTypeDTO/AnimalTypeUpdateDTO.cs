﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.AnimalTypeDTO
{
    public class AnimalTypeUpdateDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class AnimalTypeUpdateDTOValidation : AbstractValidator<AnimalTypeUpdateDTO>
    {
        public AnimalTypeUpdateDTOValidation()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
        }
    }
}
