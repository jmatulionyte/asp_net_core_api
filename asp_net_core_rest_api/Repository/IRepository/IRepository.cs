using System;
using asp_net_core_rest_api.Models;
using System.Linq.Expressions;

namespace asp_net_core_rest_api.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
        //get specific T class by linq expression as param
        //linq expression(func) on the class 'T'
        //func need to be provided output result - bool (e.g. u=> u.Id = id - return bool)
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);

        //no tracking from EF
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);

        Task CreateAsync(T entity);

        Task RemoveAsync(T entity);

        Task SaveAsync();

    }
}

