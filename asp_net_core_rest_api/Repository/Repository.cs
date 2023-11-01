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
            //when class created villanumbers table add value wfrom
            //Villa table where values for 'Villa' are the same?
            //_db.VillaNumbers.Include(u => u.Villa).ToList();
            //this is used to refer to currect objects property, avoids refering to inherited/implemented class property
            this.dbSet = _db.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
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
            
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            //here query will be executed.this is deffered execution, toList causes immediate execution
            return await query.FirstOrDefaultAsync();
        }
        //in theory 'includeProperties' could be "villa, villaSpecial. etc"
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (pageSize > 0)
            {
                if (pageSize > 100)
                {
                    pageSize = 100;
                }
                //skiping pages/recors for pagination
                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            }
            //include additional data to DTM
            if (includeProperties != null)
            {
                foreach(var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
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

