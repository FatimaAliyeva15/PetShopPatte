using AutoMapper;
using PetShopPatte_Business.DTOs.SizeDTO;
using PetShopPatte_Business.Exceptions.SizeExceptions;
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
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public void AddSize(SizeCreateDTO sizeCreateDTO)
        {
            Size size = _mapper.Map<Size>(sizeCreateDTO);

            if (size == null)
                throw new NullSizeException("Size cnnot be null");

            if(!_sizeRepository.GetAll().Any(x => x.SizeName == size.SizeName))
            {
                _sizeRepository.Add(size);
                _sizeRepository.Commit();
            }
            else
            {
                throw new DuplicateSizeException("SizeName", "Size name cannot be the same");
            }
        }

        public ICollection<SizeGetDTO> GetAllSizes(Func<Size, bool>? func = null)
        {
            var sizes = _sizeRepository.GetAll(func);

            ICollection<SizeGetDTO> sizeGetDTOs = new List<SizeGetDTO>();
            foreach (var size in sizes)
            {
                SizeGetDTO sizeGetDTO = new SizeGetDTO()
                {
                    Id = size.Id,
                    SizeName = size.SizeName,
                };

                sizeGetDTOs.Add(sizeGetDTO);
            }
            return sizeGetDTOs;
        }

        public SizeGetDTO GetSize(Func<Size, bool>? func = null)
        {
            var size = _sizeRepository.Get(func);

            SizeGetDTO sizeGetDTO = _mapper.Map<SizeGetDTO>(size);
            return sizeGetDTO;
        }

        public void HardDeleteSize(int id)
        {
            var existSize = _sizeRepository.Get(x => x.Id == id);

            if (existSize == null)
                throw new NullSizeException("Size cannot be null");

            _sizeRepository.HardDelete(existSize);
            _sizeRepository.Commit();
        }

        public void SoftDeleteSize(int id)
        {
            var existSize = _sizeRepository.Get(x => x.Id == id);

            if (existSize == null)
                throw new NullSizeException("Size cannot be null");

            _sizeRepository.SoftDelete(existSize);
            _sizeRepository.Commit();
        }

        public void UpdateSize(SizeUpdateDTO sizeUpdateDTO)
        {
            var existSize = _sizeRepository.Get(x => x.Id == sizeUpdateDTO.Id);

            if (existSize == null)
                throw new NullSizeException("Size cannot be null");

            existSize.SizeName = sizeUpdateDTO.SizeName;
            _sizeRepository.Commit();
        }
    }
}
