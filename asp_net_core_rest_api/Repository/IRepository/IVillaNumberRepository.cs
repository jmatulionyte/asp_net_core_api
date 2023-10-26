using System;
using System.Linq.Expressions;
using asp_net_core_rest_api.Models;

namespace asp_net_core_rest_api.Repository.IRepository
{
	public interface IVillaNumberRepository : IRepository<VillaNumber>
	{
		//create, remove, update VillaNumber, convert from model to dto and vice versa

		Task <VillaNumber> UpdateAsync(VillaNumber entity);
    }
}

