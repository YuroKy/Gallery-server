using Gallery.Server.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Server.Data.Implementation
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly ApplicationContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public Repository(ApplicationContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}

		public void Insert(TEntity item)
		{
			_dbSet.Add(item);
		}

		public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
		{
			return _dbSet.Where(predicate).ToList();
		}

		public IEnumerable<TEntity> Get()
		{
			return _dbSet.ToList();
		}

		public void Remove(TEntity item)
		{
			_dbSet.Remove(item);
		}

		public void Update(TEntity item)
		{
			_dbSet.Update(item);
		}

		public IEnumerable<TEntity> GetAsNoTracking(Func<TEntity, bool> predicate)
		{
			return _dbSet.AsNoTracking().Where(predicate).ToList();
		}

		public IEnumerable<TEntity> GetAsNoTracking()
		{
			return _dbSet.AsNoTracking().ToList();
		}


		public async Task InsertAsync(TEntity item)
		{
			await _dbSet.AddAsync(item);
		}

		public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Include(includeProperties).ToList();
		}

		public IEnumerable<TEntity> GetWithIncludeAsNoTracking(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return IncludeAsNoTracking(includeProperties).ToList();
		}


		public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Include(includeProperties).Where(predicate).ToList();
		}

		public IEnumerable<TEntity> GetWithIncludeAsNoTracking(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return IncludeAsNoTracking(includeProperties).Where(predicate).ToList();
		}

		#region private
		private IQueryable<TEntity> IncludeAsNoTracking(params Expression<Func<TEntity, Object>>[] includeProperties)
		{
			IQueryable<TEntity> query = _dbSet.AsNoTracking();
			return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}

		private IQueryable<TEntity> Include(params Expression<Func<TEntity, Object>>[] includeProperties)
		{
			return includeProperties.Aggregate((IQueryable<TEntity>)_dbSet, (current, includeProperty) => current.Include(includeProperty));
		}
		#endregion
	}
}
