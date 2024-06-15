using AutoMapper;
using PetShopPatte_Business.DTOs.ColorDTO;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities;
using PetShopPatte_Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Concretes
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public void AddColor(ColorCreateDTO colorCreateDTO)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ColorGetDTO> GetAllColors()
        {
            throw new NotImplementedException();
        }

        public ColorGetDTO GetColor(Func<Color, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public void HardDeleteColor(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteColor(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateColor(ColorUpdateDTO colorUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
