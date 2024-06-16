using AutoMapper;
using PetShopPatte_Business.DTOs.ColorDTO;
using PetShopPatte_Business.Exceptions.ColorExceptions;
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
            Color color = _mapper.Map<Color>(colorCreateDTO);

            if (color == null)
                throw new NullColorException("Color cannot be null");

            if(!_colorRepository.GetAll().Any(x => x.ColorName == color.ColorName))
            {
                _colorRepository.Add(color);
                _colorRepository.Commit();
            }
            else
            {
                throw new DuplicateColorException("ColorName", "Color name cannot be the same");
            }
        }

        public ICollection<ColorGetDTO> GetAllColors(Func<Color, bool>? func = null)
        {
            var colors = _colorRepository.GetAll(func);

            ICollection<ColorGetDTO> colorGetDTOs = new List<ColorGetDTO>();

            foreach (var color in colors)
            {
                ColorGetDTO colorGetDTO = new ColorGetDTO()
                {
                    Id = color.Id,
                    ColorName = color.ColorName,
                };

                colorGetDTOs.Add(colorGetDTO);
            }

            return colorGetDTOs;
        }

        public ColorGetDTO GetColor(Func<Color, bool>? func = null)
        {
            var color = _colorRepository.Get(func);

            ColorGetDTO colorGetDTO = _mapper.Map<ColorGetDTO>(color);
            return colorGetDTO;
        }

        public void HardDeleteColor(int id)
        {
            var existColor = _colorRepository.Get(x => x.Id == id);

            if (existColor == null)
                throw new NullColorException("Color cannot be null");

            _colorRepository.HardDelete(existColor);
            _colorRepository.Commit();
        }

        public void SoftDeleteColor(int id)
        {
            var existColor = _colorRepository.Get(x => x.Id == id);

            if (existColor == null)
                throw new NullColorException("Color cannot be null");

            _colorRepository.SoftDelete(existColor);
            _colorRepository.Commit();
        }

        public void UpdateColor(ColorUpdateDTO colorUpdateDTO)
        {
            var existColor = _colorRepository.Get(x => x.Id == colorUpdateDTO.Id);

            if (existColor == null)
                throw new NullColorException("Color cannot be null");

            existColor.ColorName = colorUpdateDTO.ColorName;
            _colorRepository.Commit();
        }
    }
}
