﻿using Microsoft.EntityFrameworkCore;
using PetShopPatte_Core.Entities.PatteDb;
using PetShopPatte_Data.DAL;
using PetShopPatte_Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Repositories.Concretes
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<PetDetail> GetPetDetailByIdAsync(int id)
        {
            return await _appDbContext.PetDetails
                                 .Include(pd => pd.Pet) 
                                 .FirstOrDefaultAsync(pd => pd.Id == id);
        }

    }
}
