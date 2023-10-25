using System;
using System.Linq.Expressions;
using asp_net_core_rest_api.Data;
using asp_net_core_rest_api.Models;
using asp_net_core_rest_api.Repository.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace asp_net_core_rest_api.Repository
{
    //implement irepository - inherit describtion of methods
    //Repository<Villa> - provides implmentation of interface with create, getall,get,delete tasks
    //IVillaRepository - provided implementation of Update
    public class VillaRepository : Repository<Villa>, IVillaRepository
	{
        private readonly ApplicationDbContext _db;

        //dependency injection
        public VillaRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        //update is implemented custom way, thats why Repository<Villa.Update.. is hidden...
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

