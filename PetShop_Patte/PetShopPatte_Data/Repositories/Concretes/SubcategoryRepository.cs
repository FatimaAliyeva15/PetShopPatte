using Microsoft.EntityFrameworkCore;
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
    public class SubcategoryRepository : GenericRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
