using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
        private readonly DbSet<T> _table;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentException(nameof(appDbContext));
            _table = _appDbContext.Set<T>();
        }
        

        public async Task<T> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _table.Update(entity);
            return entity;
        }

        public async Task DeleteDb(int id)
        {
            var entity = await _table.FirstOrDefaultAsync(x => x.Id == id);
            _table.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id, params string[] entityIncludes)
        {
            return await CheckEntity(id, entityIncludes);
        }


        public async Task<int> Commit()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _table.AnyAsync(x => x.Id == id && !x.IsDeleted);
        }




        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? func = null, Expression<Func<T, object>>? orderBy = null, bool isOrderByDesting = false, params string[] includes)
        {
            IQueryable<T> query = _table;

            if (func is not null)
            {
                query = query.Where(func);
            }
            if (orderBy is not null)
            {
                query = isOrderByDesting ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }

        public async Task<T> CheckEntity(int id, params string[] entityIncludes)
        {
            IQueryable<T> query = await GetAllAsync();
            if (entityIncludes is not null)
            {
                for (int i = 0; i < entityIncludes.Length; i++)
                {
                    query = query.Include(entityIncludes[i]);
                }
            }

            var entity = await query.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<T> HardDelete(int id)
        {
            var entity = await GetByIdAsync(id);

            entity.IsDeleted = true;
            await UpdateAsync(entity);

            return entity;
        }

        public async Task<T> SoftDelete(int id)
        {
            var entity = await GetByIdAsync(id);

            entity.IsDeleted = false;
            await UpdateAsync(entity);

            return entity;
        }
    }
}
