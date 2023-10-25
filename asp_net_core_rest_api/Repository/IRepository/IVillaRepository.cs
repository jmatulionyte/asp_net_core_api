using System;
using System.Linq.Expressions;
using asp_net_core_rest_api.Models;

namespace asp_net_core_rest_api.Repository.IRepository
{
	public interface IVillaRepository
	{
		//create, remove, update Villa, convert from model to dto and vice versa

		//get specific villa by linq expression as param
		//linq expression(func) on the class 'villa'
		Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null);

		//no tracking from EF
        Task<Villa> Get(Expression<Func<Villa>> filter = null, bool tracked=true);

        Task Create(Villa entity);

        Task Remove(Villa entity);

		Task Save(); //DB



    }
}

