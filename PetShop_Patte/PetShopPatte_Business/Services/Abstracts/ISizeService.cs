using PetShopPatte_Business.DTOs.SizeDTO;
using PetShopPatte_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface ISizeService
    {
        void AddSize(SizeCreateDTO sizeCreateDTO);
        void UpdateSize(SizeUpdateDTO sizeUpdateDTO);
        void HardDeleteSize(int id);
        void SoftDeleteSize(int id);
        SizeGetDTO GetSize(Func<Size, bool>? func = null);
        IQueryable<SizeGetDTO> GetAllSizes();
    }
}
