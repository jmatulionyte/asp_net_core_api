using System;
using System.Linq.Expressions;
using asp_net_core_rest_api.Models;

namespace asp_net_core_rest_api.Repository.IRepository
{
	public interface IVillaRepository : IRepository<Villa>
	{
		//create, remove, update Villa, convert from model to dto and vice versa

		Task <Villa> UpdateAsync(Villa entity);
    }
}

