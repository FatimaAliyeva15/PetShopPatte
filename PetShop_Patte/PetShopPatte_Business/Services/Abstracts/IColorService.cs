﻿using PetShopPatte_Business.DTOs.ColorDTO;
using PetShopPatte_Core.Entities.PatteDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IColorService
    {
        void AddColor(ColorCreateDTO colorCreateDTO);
        void UpdateColor(ColorUpdateDTO colorUpdateDTO);
        void HardDeleteColor(int id);
        void SoftDeleteColor(int id);
        ColorGetDTO GetColor(Func<Color, bool>? func = null);
        ICollection<ColorGetDTO> GetAllColors(Func<Color, bool>? func = null);
    }
}
