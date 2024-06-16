using Microsoft.EntityFrameworkCore;
using PetShopPatte_Core.Entities.Common;
using PetShopPatte_Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext;


        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public T Get(Func<T, bool>? func = null)
        {
            return func == null ?
                _appDbContext.Set<T>().FirstOrDefault() :
                _appDbContext.Set<T>().Where(func).FirstOrDefault();
        }

        public ICollection<T> GetAll(Func<T, bool>? func = null)
        {
            return func == null ?
               _appDbContext.Set<T>().ToList() :
               _appDbContext.Set<T>().Where(func).ToList();
        }

        //public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? func = null, Expression<Func<T, object>>? orderBy = null, bool isOrderByDesting = false, params string[]? includes)
        //{
        //    IQueryable<T> data = _appDbContext.Set<T>();

        //    if(includes is not null)
        //    {
        //        for(int i = 0; i < includes.Length; i++)
        //        {
        //            data = data.Include(includes[i]);
        //        }
        //    }

        //    if(orderBy is not null)
        //    {
        //        data = isOrderByDesting ?
        //            data.OrderByDescending(orderBy) :
        //            data.OrderBy(orderBy);
        //    }

        //    return func == null ? data : data.Where(func);
        //}

        public void HardDelete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
        }
    }
}
