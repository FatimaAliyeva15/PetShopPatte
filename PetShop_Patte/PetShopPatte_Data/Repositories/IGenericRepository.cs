using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task HardDelete(int id);
        Task<T> SoftDelete(int id);
        Task<T> Recover(int id);
        Task<T> GetByIdAsync(int id, params string[] entityIncludes);
        Task<T> CheckEntity(int id, params string[] entityIncludes);

        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? func = null,
            Expression<Func<T, object>>? orderBy = null,
            bool isOrderByDesting = false,
            params string[] includes);

        Task<int> Commit();
        Task<bool> IsExists(int id);
    }
}
