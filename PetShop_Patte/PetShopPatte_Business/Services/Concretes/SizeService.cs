using AutoMapper;
using FluentValidation;
using PetShopPatte_Business.DTOs.CategoryDTO;
using PetShopPatte_Business.DTOs.SizeDTO;
using PetShopPatte_Business.Exceptions.CategoryExceptions;
using PetShopPatte_Business.Exceptions.SizeExceptions;
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
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IValidator<Size> _validator;

        public SizeService(ISizeRepository sizeRepository, IValidator<Size> validator)
        {
            _sizeRepository = sizeRepository;
            _validator = validator;
        }

        public async Task AddSize(SizeCreateDTO sizeCreateDTO)
        {
            Size size = new Size()
            {
                SizeName = sizeCreateDTO.SizeName,
            };

            if (size == null)
                throw new NullSizeException("Size cannot be null");

            var sizes = await _sizeRepository.GetAllAsync();

            if (!sizes.Any(x => x.SizeName == size.SizeName))
            {
                await _sizeRepository.AddAsync(size);
                await _sizeRepository.Commit();
            }
            else
            {
                throw new DuplicateSizeException("SizeName", "Size name cannot be the same");
            }
        }

        public async Task<IQueryable<Size>> GetAllSizes()
        {
            return await _sizeRepository.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new SizeIdNegativeorZeroException("Size id not negative and zero");

            return await _sizeRepository.GetByIdAsync(id);
        }

        public async Task HardDeleteSize(int id)
        {
            if (id <= 0)
                throw new SizeIdNegativeorZeroException("Size id not negative and zero");

            await _sizeRepository.HardDelete(id);
            await _sizeRepository.Commit();
        }

        public async Task Recover(int id)
        {
            if (id <= 0)
                throw new SizeIdNegativeorZeroException("Size id not negative and zero");

            await _sizeRepository.Recover(id);
            await _sizeRepository.Commit();
        }

        public async Task SoftDeleteSize(int id)
        {
            if (id <= 0)
                throw new SizeIdNegativeorZeroException("Size id not negative and zero");

            await _sizeRepository.SoftDelete(id);
            await _sizeRepository.Commit();
        }

        public async Task<SizeUpdateDTO> UpdateById(int id)
        {
            if (id <= 0)
                throw new SizeIdNegativeorZeroException("Size id not negative and zero");

            if (await _sizeRepository.IsExists(id))
            {

                var size = await _sizeRepository.GetByIdAsync(id);

                SizeUpdateDTO sizeUpdateDTO = new SizeUpdateDTO()
                {
                    SizeName = size.SizeName,
                };

                return sizeUpdateDTO;
            }
            else
            {
                throw new Exceptions.SizeExceptions.EntityNotFoundException("", "Entity not found");
            }
        }

        public async Task UpdateSize(SizeUpdateDTO sizeUpdateDTO)
        {
            var existSize = await _sizeRepository.GetByIdAsync(sizeUpdateDTO.Id);

            if (existSize == null)
                throw new NullSizeException("Size cannot be null");

            existSize.SizeName = sizeUpdateDTO.SizeName ?? existSize.SizeName;

            _sizeRepository.Update(existSize);
            await _sizeRepository.Commit();
        }
    }
}
