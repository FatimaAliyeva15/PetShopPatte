using AutoMapper;
using FluentValidation;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.ColorDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Exceptions.ColorExceptions;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.Repositories.Abstracts;
using PetShopPatte_Data.Repositories.Concretes;
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
        private readonly IValidator<ColorUpdateDTO> _validator;

        public ColorService(IColorRepository colorRepository, IMapper mapper, IValidator<ColorUpdateDTO> validator)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task AddColor(ColorCreateDTO colorCreateDTO)
        {
            Color color = new Color()
            {
                ColorName = colorCreateDTO.ColorName,
            };

            if (color == null)
                throw new NullColorException("Color cannot be null");

            var colors = await _colorRepository.GetAllAsync();

            if (!colors.Any(x => x.ColorName == color.ColorName))
            {
                await _colorRepository.AddAsync(color);
                await _colorRepository.Commit();
            }
            else
            {
                throw new DuplicateColorException("ColorName", "Color name cannot be the same");
            }
        }

        public async Task<IQueryable<Color>> GetAllColors()
        {
            
            return await _colorRepository.GetAllAsync();
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ColorIdNegativeorZeroException("Color id not negative and zero");

            return await _colorRepository.GetByIdAsync(id);
        }

        public async Task HardDeleteColor(int id)
        {
            if (id <= 0)
                throw new ColorIdNegativeorZeroException("Color id not negative and zero");

            await _colorRepository.HardDelete(id);
            await _colorRepository.Commit();
        }

        public async Task Recover(int id)
        {

            if (id <= 0)
                throw new ColorIdNegativeorZeroException("Color id not negative and zero");

            await _colorRepository.Recover(id);
            await _colorRepository.Commit();
        }

        public async Task SoftDeleteColor(int id)
        {

            if (id <= 0)
                throw new ColorIdNegativeorZeroException("Color id not negative and zero");

            await _colorRepository.SoftDelete(id);
            await _colorRepository.Commit();
        }

        public async Task<ColorUpdateDTO> UpdateById(int id)
        {

            if (id <= 0)
                throw new ColorIdNegativeorZeroException("Color id not negative and zero");

            if (await _colorRepository.IsExists(id))
            {

                var color = await _colorRepository.GetByIdAsync(id);

                ColorUpdateDTO colorUpdateDTO = new ColorUpdateDTO()
                {
                    ColorName = color.ColorName,
                };

                return colorUpdateDTO;
            }
            else
            {
                throw new Exceptions.ColorExceptions.EntityNotFoundException("", "Entity not found");
            }
        }

        public async Task UpdateColor(ColorUpdateDTO colorUpdateDTO)
        {
            var existColor = await _colorRepository.GetByIdAsync(colorUpdateDTO.Id);

            if (existColor == null)
                throw new NullColorException("Color cannot be null");

            existColor.ColorName = colorUpdateDTO.ColorName ?? existColor.ColorName;

            _colorRepository.Update(existColor);
            await _colorRepository.Commit();
        }
    }
}
