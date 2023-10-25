using System;
using System.Linq.Expressions;
using asp_net_core_rest_api.Data;
using asp_net_core_rest_api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace asp_net_core_rest_api.Repository.IRepository
{
    //implement irepository - inherit describtion of methods
	public class VillaRepository : IVillaRepository
	{
        private readonly ApplicationDbContext _db;

        //dependency injection
        public VillaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Villa entity)
        {
            await _db.Villas.AddAsync(entity);
            await Save();
        }

        public Task<Villa> Get(Expression<Func<Villa>> filter = null, bool tracked = true)
        {
            throw new NotImplementedException();
        }

        public Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Villa entity)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}

