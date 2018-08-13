using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Server.Data.Abstractions
{
	public interface IRepository<TEntity>
	{
		IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
		IEnumerable<TEntity> Get();
		IEnumerable<TEntity> GetAsNoTracking(Func<TEntity, bool> predicate);
		IEnumerable<TEntity> GetAsNoTracking();
		IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
		IEnumerable<TEntity> GetWithIncludeAsNoTracking(params Expression<Func<TEntity, object>>[] includeProperties);
		IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
		IEnumerable<TEntity> GetWithIncludeAsNoTracking(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
		void Insert(TEntity item);
		void Update(TEntity item);
		void Remove(TEntity item);
		Task InsertAsync(TEntity item);
	}
}
