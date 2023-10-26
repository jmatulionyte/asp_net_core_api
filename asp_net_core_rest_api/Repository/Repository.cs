using System;
using asp_net_core_rest_api.Data;
using asp_net_core_rest_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using asp_net_core_rest_api.Repository.IRepository;

namespace asp_net_core_rest_api.Repository
{
    public class Repository<T> : IRepository<T> where T : class
 	{
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        //dependency injection
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //this is used to refer to currect objects property, avoids refering to inherited/implemented class property
            this.dbSet = _db.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking(); //do no track queries
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //here query will be executed.this is deffered execution, toList causes immediate execution
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //here query will be executed.this is deffered execution, toList causes immediate execution
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Villa entity)
        {
            _db.Villas.Update(entity);
            await SaveAsync();
        }
    }
}

