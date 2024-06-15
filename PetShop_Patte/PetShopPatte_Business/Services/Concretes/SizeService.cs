using AutoMapper;
using PetShopPatte_Business.DTOs.SizeDTO;
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
            throw new NotImplementedException();
        }

        public IQueryable<SizeGetDTO> GetAllSizes()
        {
            throw new NotImplementedException();
        }

        public SizeGetDTO GetSize(Func<Size, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public void HardDeleteSize(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteSize(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSize(SizeUpdateDTO sizeUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
