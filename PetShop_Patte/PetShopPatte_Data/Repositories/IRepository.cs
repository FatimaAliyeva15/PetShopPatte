using PetShopPatte_Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        void Add(T entity);
        void HardDelete(T entity);
        void SoftDelete(T entity);
        T Get(Func<T, bool>? func = null);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? func = null,
            Expression<Func<T, object>>? orderBy = null,
            bool isOrderByDesting = false,
            params string[]? includes);
        int Commit();
    }
}
